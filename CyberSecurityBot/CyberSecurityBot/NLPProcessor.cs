using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    public class NLPProcessor
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("password") || input.Contains("login") || input.Contains("account"))
                return "password";

            if (input.Contains("phishing") || input.Contains("email") || input.Contains("scam"))
                return "phishing";

            if (input.Contains("privacy") || input.Contains("data"))
                return "privacy";

            if (input.Contains("ransomware") || input.Contains("virus"))
                return "ransomware";

            if (input.Contains("safe browsing") || input.Contains("internet"))
                return "safe_browsing";

            return "unknown";
        }

        public string DetectSentiment(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried")) return "worried";
            if (input.Contains("confused")) return "confused";
            if (input.Contains("frustrated")) return "frustrated";
            if (input.Contains("curious")) return "curious";

            return "neutral";
        }
    }
}
