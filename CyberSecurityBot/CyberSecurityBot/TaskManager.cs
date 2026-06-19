using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(string title)
        {
            tasks.Add(new TaskItem()
            {
                Title = title,
                Description = "",
                Reminder = "",
                Completed = false
            });
        }

        public void SetReminder(string reminder)
        {
            if (tasks.Count > 0)
            {
                tasks[tasks.Count - 1].Reminder = reminder;
            }
        }

        public string ShowTasks()
        {
            if (tasks.Count == 0)
                return "No tasks available.";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Your Tasks");

            foreach (TaskItem task in tasks)
            {
                sb.AppendLine("--------------------------------");
                sb.AppendLine("Task: " + task.Title);
                sb.AppendLine("Reminder: " + task.Reminder);
                sb.AppendLine("Completed: " + task.Completed);
            }

            return sb.ToString();
        }
    }
}
