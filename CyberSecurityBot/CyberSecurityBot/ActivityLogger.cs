using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    public class ActivityLogger
    {
        private List<string> log = new List<string>();

        public void Add(string action)
        {
            log.Add(action);
        }

        public string ShowLog()
        {
            if (log.Count == 0)
                return "No activity recorder.";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Activity Log:");

            sb.AppendLine("--------------------");

            foreach (string item in log)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }
    }
}
