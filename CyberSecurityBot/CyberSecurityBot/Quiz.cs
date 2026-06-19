using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    public class Quiz
    {
        public class Question
        {
            public string Text;
            public string[] Options;
            public int CorrectAnswer;
        }

        private List<Question> questions = new List<Question>();

        public int CurrentQuestion = 0;
        public int Score = 0;

        public Quiz()
        {
            questions.Add(new Question
            {
                Text = "What should you do if you receive an email asking for your password?",
                Options = new string[]
                {
                    "A. Reply with your password",
                    "B. Delete the email",
                    "C. Report it as phishing",
                    "D. Ignore your antivirus"
                },
                CorrectAnswer = 2
            });

            questions.Add(new Question
            {
                Text = "What makes a strong password?",
                Options = new string[]
                {
                    "A. 123456",
                    "B. Your name",
                    "C. Long with letters, numbers and symbols",
                    "D. Password"
                },
                CorrectAnswer = 2
            });

            questions.Add(new Question
            {
                Text = "What does HTTPS mean on a website?",
                Options = new string[]
                {
                    "A. Secure connection",
                    "B. Free WiFi",
                    "C. Fast website",
                    "D. Virus detected"
                },
                CorrectAnswer = 0
            });

            questions.Add(new Question
            {
                Text = "What should you do before downloading files?",
                Options = new string[]
                {
                    "A. Download everything",
                    "B. Check if the source is trusted",
                    "C. Disable antivirus",
                    "D. Ignore warnings"
                },
                CorrectAnswer = 1
            });

            questions.Add(new Question
            {
                Text = "Two-factor authentication helps by...",
                Options = new string[]
                {
                    "A. Slowing your computer",
                    "B. Adding extra account security",
                    "C. Deleting passwords",
                    "D. Blocking WiFi"
                },
                CorrectAnswer = 1
            });

            questions.Add(new Question
            {
                Text = "Which is an example of phishing?",
                Options = new string[]
                {
                    "A. Fake bank email",
                    "B. Windows update",
                    "C. Calculator",
                    "D. Notepad"
                },
                CorrectAnswer = 0
            });

            questions.Add(new Question
            {
                Text = "Why should software be updated?",
                Options = new string[]
                {
                    "A. For security patches",
                    "B. To reduce storage",
                    "C. To delete files",
                    "D. No reason"
                },
                CorrectAnswer = 0
            });

            questions.Add(new Question
            {
                Text = "What should you do if you click a suspicious link?",
                Options = new string[]
                {
                    "A. Ignore it",
                    "B. Scan your computer",
                    "C. Share it",
                    "D. Turn off WiFi forever"
                },
                CorrectAnswer = 1
            });

            questions.Add(new Question
            {
                Text = "What is ransomware?",
                Options = new string[]
                {
                    "A. A game",
                    "B. Malware that locks files",
                    "C. Browser",
                    "D. Email service"
                },
                CorrectAnswer = 1
            });

            questions.Add(new Question
            {
                Text = "Backing up files helps protect against...",
                Options = new string[]
                {
                    "A. Ransomware",
                    "B. Slow internet",
                    "C. Low battery",
                    "D. Keyboard problems"
                },
                CorrectAnswer = 0
            });
        }

        public Question GetCurrentQuestion()
        {
            if (CurrentQuestion >= questions.Count)
                return null;

            return questions[CurrentQuestion];
        }

        public bool CheckAnswer(int answer)
        {
            bool correct = answer == questions[CurrentQuestion].CorrectAnswer;

            if (correct)
                Score++;

            CurrentQuestion++;

            return correct;
        }

        public bool Finished()
        {
            return CurrentQuestion >= questions.Count;
        }
    }
}
