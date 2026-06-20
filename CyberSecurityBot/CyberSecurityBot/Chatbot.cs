using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    public class Chatbot
    {
        private Random random = new Random();

        private TaskManager taskManager = new TaskManager();
        private ActivityLogger activityLog = new ActivityLogger();
        private Quiz quiz = new Quiz();
        private NLPProcessor nlp = new NLPProcessor();


        private TaskRepository taskRepo = new TaskRepository();

        private string userName = "";
        private string favoriteTopic = "";
        private string tempTitle = "";
        private string tempDescription = "";

        private bool quizMode = false;
        private bool waitingForTask = false;
        private bool waitingForReminder = false;
        private bool waitingForReminderTime = false;
        private bool waitingForDescription = false;
        private bool waitingForReminderChoice = false;
        

        public string GetResponse(string input)
        {
            input = input.Trim().ToLower();

            activityLog.Add("User input: " + input);

            // =========================
            // GREETINGS
            // =========================
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey") || input.Contains("good morning") || input.Contains("good afternoon") || input.Contains("good evening"))
            {
                activityLog.Add("Greeting detected");
                if (userName != "")
                    return "Hello " + userName + "! How can I help you today?";

                return "Hello! Welcome to the Cybersecurity Awareness Bot.";
                
            }

            // =========================
            // NLP PROCESSING
            // =========================
            string intent = nlp.DetectIntent(input);
            string sentiment = nlp.DetectSentiment(input);

            if (sentiment != "neutral")
                activityLog.Add("Sentiment: " + sentiment);

            // =========================
            // TASK SYSTEM
            // =========================

            if (input == "add task")
            {
                waitingForTask = true;
                return "Enter task title:";
            }

            if (waitingForTask)
            {
                tempTitle = input;

                waitingForTask = false;
                waitingForDescription = true;

                return "Enter task description:";
            }

            if (waitingForDescription)
            {
                tempDescription = input;

                waitingForDescription = false;
                waitingForReminderChoice = true;

                return "Do you want to set a reminder? (yes/no)";
            }

            if (waitingForReminderChoice)
            {
                if (input == "yes")
                {
                    waitingForReminderChoice = false;
                    waitingForReminderTime = true;

                    return "When should I remind you? (e.g. tomorrow, 3 days, next week)";
                }

                // NO reminder → save immediately
                taskRepo.AddTask(tempTitle, tempDescription, null);

                activityLog.Add("Task saved without reminder");

                waitingForReminderChoice = false;

                tempTitle = "";
                tempDescription = "";

                return "Task saved successfully (no reminder set).";
            }

            if (waitingForReminderTime)
            {
                DateTime? reminderDate = ParseReminder(input);

                taskRepo.AddTask(
                    tempTitle,
                    tempDescription,
                    reminderDate?.ToString("yyyy-MM-dd HH:mm")
                );

                activityLog.Add("Task saved with reminder: " + input);

                waitingForReminderTime = false;

                tempTitle = "";
                tempDescription = "";

                return "Task saved successfully with reminder set.";
            }



            // =========================
            // MEMORY
            // =========================
            if (input.StartsWith("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();
                activityLog.Add("Name saved: " + userName);
                return "Nice to meet you " + userName;
            }

            if (input.Contains("who am i"))
                return userName == "" ? "I don't know yet." : "You are " + userName;

            // =========================
            // NLP INTENT RESPONSES
            // =========================
            if (intent == "password")
            {
                activityLog.Add("Intent: password security");
                return "Use strong passwords with letters, numbers and symbols.";
            }

            if (intent == "phishing")
            {
                activityLog.Add("Intent: phishing");
                return "Never click suspicious email links.";
            }

            if (intent == "privacy")
            {
                activityLog.Add("Intent: privacy");
                return "Keep your personal data private and enable 2FA.";
            }

            if (intent == "ransomware")
            {
                activityLog.Add("Intent: ransomware");
                return "Back up your files and keep antivirus updated.";
            }

            if (intent == "safe_browsing")
            {
                activityLog.Add("Intent: safe browsing");
                return "Only use HTTPS websites and trusted sources.";
            }

            if (input.Contains("how can i protect") || input.Contains("how do i secure"))
            {
                return "To improve your cybersecurity, follow best practices like using strong passwords, enabling two-factor authentication, keeping software updated, being cautious of phishing attempts, and regularly backing up important data.";
            }

            // =========================
            // QUIZ GAME
            // =========================
            if (input == "start quiz")
            {
                quiz = new Quiz();
                quizMode = true;

                activityLog.Add("Quiz started");

                var q = quiz.GetCurrentQuestion();

                return q.Text + "\n" + string.Join("\n", q.Options);
            }

            if (quizMode)
            {
                int answer = -1;

                if (input == "a") answer = 0;
                else if (input == "b") answer = 1;
                else if (input == "c") answer = 2;
                else if (input == "d") answer = 3;

                if (answer == -1)
                    return "Answer with A, B, C or D";

                bool correct = quiz.CheckAnswer(answer);

                activityLog.Add("Quiz answer: " + input);

                if (quiz.Finished())
                {
                    quizMode = false;
                    activityLog.Add("Quiz finished");

                    return "Quiz complete! Score: " + quiz.Score;
                }

                var next = quiz.GetCurrentQuestion();

                return (correct ? "Correct!\n\n" : "Wrong!\n\n")
                    + next.Text + "\n" + string.Join("\n", next.Options);
            }

            // =========================
            // TASK START
            // =========================
            if (input.Contains("show tasks") || input.Contains("view tasks") || input.Contains("list tasks"))
            {
                var tasks = taskRepo.GetTasks();

                activityLog.Add("Viewed tasks");

                if (tasks.Count == 0)
                    return "No tasks found.";

                return "Cybersecurity Tasks:\n\n" + string.Join("\n\n", tasks);
            }

            if (input.StartsWith("delete task"))
            {
                try
                {
                    int id = int.Parse(input.Replace("delete task", "").Trim());
                    taskRepo.DeleteTask(id);

                    activityLog.Add("Deleted task: " + id);
                    return "Task deleted successfully.";
                }
                catch
                {
                    return "Please enter valid task ID. Example: delete task 1";
                }
            }

            if (input.StartsWith("complete task"))
            {
                try
                {
                    int id = int.Parse(input.Replace("complete task", "").Trim());

                    taskRepo.MarkCompleted(id);

                    activityLog.Add("Completed task: " + id);

                    return "Task marked as completed.";
                }
                catch
                {
                    return "Please enter a valid task ID. Example: complete task 1";
                }
            }

            // =========================
            // ACTIVITY LOG
            // =========================
            if (input == "show activity")
                return activityLog.ShowLog();

            // =========================
            // HELP
            // =========================
            if (input == "help")
            {
                return "Ask about phishing, passwords, privacy, ransomware, safe browsing.\nCommands: add task, start quiz, show tasks, show activity";
            }

            // =========================
            // DEFAULT
            // =========================
            return "I didn't understand. Type help.";
        }

        private DateTime? ParseReminder(string input)
        {
            input = input.ToLower();

            if (input.Contains("tomorrow"))
                return DateTime.Now.AddDays(1);

            if (input.Contains("next week"))
                return DateTime.Now.AddDays(7);

            if (input.Contains("3 days"))
                return DateTime.Now.AddDays(3);

            if (input.Contains("7 days"))
                return DateTime.Now.AddDays(7);

            return null;
        }
    }
}
