using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CyberSecurityBot
{
    public partial class MainForm : Form
    {
        Chatbot bot = new Chatbot();

        public MainForm()
        {
            InitializeComponent();

            PlayGreeting();

            rtbChat.AppendText("=============================================\n");
            rtbChat.AppendText("      CYBERSECURITY AWARENESS BOT\n");
            rtbChat.AppendText("=============================================\n\n");

            rtbChat.AppendText("Welcome!\n");
            rtbChat.AppendText("I'm here to help you stay safe online.\n\n");

            rtbChat.AppendText("Type HELP to see everything I can do.\n\n");

            txtInput.Focus();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                e.SuppressKeyPress = true;
            }
        }

        private void SendMessage()
        {
            string userInput = txtInput.Text.Trim();

            if (userInput == "")
            {
                MessageBox.Show(
                    "Please type a message.",
                    "Input Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtInput.Focus();
                return;
            }

            rtbChat.AppendText("You: " + userInput + "\n");

            string reply = bot.GetResponse(userInput);

            rtbChat.AppendText("Bot: " + reply + "\n\n");

            rtbChat.ScrollToCaret();

            txtInput.Clear();

            txtInput.Focus();
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Welcome.wav");
                player.Play();
            }
            catch
            {
                rtbChat.AppendText("(Voice greeting unavailable.)\n\n");
            }
        }

    }
}
