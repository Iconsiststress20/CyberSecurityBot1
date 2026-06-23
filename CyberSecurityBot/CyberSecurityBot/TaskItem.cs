using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    public class TaskItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Reminder { get; set; }

        public bool Completed { get; set; }
    }
}
