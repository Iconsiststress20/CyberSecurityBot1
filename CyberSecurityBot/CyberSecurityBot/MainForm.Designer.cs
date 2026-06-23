namespace CyberSecurityBot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(31, 529);
            this.txtInput.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(670, 30);
            this.txtInput.TabIndex = 2;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitle.Location = new System.Drawing.Point(180, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(524, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cybersecurity Awareness Bot";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSend.Location = new System.Drawing.Point(731, 526);
            this.btnSend.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(130, 39);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.Black;
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChat.ForeColor = System.Drawing.Color.Lime;
            this.rtbChat.Location = new System.Drawing.Point(31, 89);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(830, 399);
            this.rtbChat.TabIndex = 1;
            this.rtbChat.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1408, 986);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnSend);
            this.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Cyan;
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MinimumSize = new System.Drawing.Size(1426, 47);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cybersecurity Awareness Bot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtbChat;
    }
}

