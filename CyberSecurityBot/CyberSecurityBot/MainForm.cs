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

            rtbChat.AppendText("Bot: Welcome to the Cybersecurity Awareness Bot!\n");
            rtbChat.AppendText("Bot: Type 'help' to see available topics.\n\n");
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
            string userInput = txtInput.Text;

            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            rtbChat.AppendText("You: " + userInput + "\n");

            string response = bot.GetResponse(userInput);

            rtbChat.AppendText("Bot: " + response + "\n\n");

            txtInput.Clear();
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
                MessageBox.Show("Audio file could not be played.");
            }
        }

    }
}
