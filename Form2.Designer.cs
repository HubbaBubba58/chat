namespace ClientApp
{
    partial class Form2
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.messagesTextBox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.labelNotification = new System.Windows.Forms.Label();
            this.notificationTextBox = new System.Windows.Forms.TextBox();
            this.labelMessages = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(268, 551);
            this.messageTextBox.MaxLength = 512;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(447, 22);
            this.messageTextBox.TabIndex = 0;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(721, 547);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(96, 30);
            this.sendBtn.TabIndex = 1;
            this.sendBtn.Text = "Отправить";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // messagesTextBox
            // 
            this.messagesTextBox.Location = new System.Drawing.Point(268, 53);
            this.messagesTextBox.Multiline = true;
            this.messagesTextBox.Name = "messagesTextBox";
            this.messagesTextBox.Size = new System.Drawing.Size(549, 476);
            this.messagesTextBox.TabIndex = 2;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(12, 24);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(46, 16);
            this.loginLabel.TabIndex = 4;
            this.loginLabel.Text = "Логин";
            // 
            // listUsers
            // 
            this.listUsers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listUsers.FormattingEnabled = true;
            this.listUsers.ItemHeight = 16;
            this.listUsers.Location = new System.Drawing.Point(12, 53);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(233, 516);
            this.listUsers.TabIndex = 3;
            this.listUsers.SelectedIndexChanged += new System.EventHandler(this.ListUsers_SelectedIndexChanged);
            // 
            // labelNotification
            // 
            this.labelNotification.AutoSize = true;
            this.labelNotification.Location = new System.Drawing.Point(845, 24);
            this.labelNotification.Name = "labelNotification";
            this.labelNotification.Size = new System.Drawing.Size(96, 16);
            this.labelNotification.TabIndex = 5;
            this.labelNotification.Text = "Уведомления";
            // 
            // notificationTextBox
            // 
            this.notificationTextBox.Location = new System.Drawing.Point(848, 53);
            this.notificationTextBox.Multiline = true;
            this.notificationTextBox.Name = "notificationTextBox";
            this.notificationTextBox.Size = new System.Drawing.Size(310, 476);
            this.notificationTextBox.TabIndex = 6;
            // 
            // labelMessages
            // 
            this.labelMessages.AutoSize = true;
            this.labelMessages.Location = new System.Drawing.Point(265, 24);
            this.labelMessages.Name = "labelMessages";
            this.labelMessages.Size = new System.Drawing.Size(80, 16);
            this.labelMessages.TabIndex = 7;
            this.labelMessages.Text = "Сообщения";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(848, 547);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(310, 30);
            this.clearBtn.TabIndex = 8;
            this.clearBtn.Text = "Очистить уведомления";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 607);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.labelMessages);
            this.Controls.Add(this.notificationTextBox);
            this.Controls.Add(this.labelNotification);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.messagesTextBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.messageTextBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox messagesTextBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.Label labelNotification;
        private System.Windows.Forms.TextBox notificationTextBox;
        private System.Windows.Forms.Label labelMessages;
        private System.Windows.Forms.Button clearBtn;
    }
}