using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    public class Chatbot
    {
        Random random = new Random();

        private string userName = "";
        private string favoriteTopic = "";

        Dictionary<string, string[]> responses = new Dictionary<string, string[]>()
        {
            {
                "password", new string[]
                {
                    "A strong password should be at least 12 characters long and include a mix of letters, numbers, and symbols.",
                    "Never reuse passwords across different accounts. Use a password manager to keep track of them."
                }
            },
            {
                "phishing", new string[]
                {
                    "Avoid clicking on suspicious links in emails or messages. Always verify email senders.", "Scammers often pretend to be trusted companies."
                }
            },

            {
                "privacy", new string[]
                {
                    "Review your privacy settings regularly.", "Do not share personal information publicly.","Enable two-factor authentication for extra protection."
                }
            },

            { "ransomware", new string[]
              {
                "Back up your files regularly.", "Avoid downloading unknown attachments.", "Keep your antivirus software up to date."
              }
            },

            {
                "safe browsing", new string[]
                {
                    "Only visit trusted and secure websites.", "Check for HTTPS before entering information.", "Avoid suspicious popups and downloading."
                }
            }
        };

        public string GetResponse(string input)
        {
            input = input.ToLower();

            // MEMORY
            if (input.Contains("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();
                return "Nice to meet you," + userName + "!";
            }

            if(input.Contains("i like"))
            {
                favoriteTopic = input.Replace("i like", "").Trim();
                return "Great! I will remember that you like " + favoriteTopic + ".";
            }

            if(input.Contains("who am i"))
            {
                if (userName != "")
                {
                    return "Your name is " + userName + ".";
                }

                return "I don't know your name yet.";
            }

            if(input.Contains("what do i like"))
            {
                if (favoriteTopic != "")
                {
                    return "You told me you like " + favoriteTopic + ".";
                }
                return "You have not told me your favorite topic yet.";
            }

            // DETECT KEYWORDS

            if (input.Contains("worried"))
            {
                return "It is understandable to feel worried about online scams.";
            }

            if (input.Contains("frustrated"))
            {
                return "I understand your frustration. Online threats can be very stressful.";
            }

            if (input.Contains("confused"))
            {
                return "Cybersecurity can be confusing at times. I'm here to help!";
            }

            if (input.Contains("curious")) 
            { 
                return "Curiosity is great! Learning about cybersecurity can help you stay safe online.";
            }

            // CONVERSATION

            if (input.Contains("tell me more"))
            {
                return "Cybersecurity protects devices, networks, and personal information from attacks.";
            }

            if (input.Contains("another tip"))
            {
                return "Always update your apps and operating system.";
            }

            // HELP

            if (input.Contains("help"))
            {
                return "You can ask me about password security, phishing, privacy, ransomware, and safe browsing.";
            }

            // GREETINGS

            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            {
                return "Hello! How can I help you stay safe online today?";
            }

            //KEYWORD RESPONSES

            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    string[] possibleResponses = responses[keyword];
                    return possibleResponses[random.Next(possibleResponses.Length)];
                }
            }

            return "I'm not sure I understand. Please ask a cybersecurity-related question.";
        }
    }
}
