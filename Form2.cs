using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientApp
{
    public struct UserMessage
    {
        public string Login { get; set; }
        public string Message { get; set; }
    }

    public partial class Form2 : Form
    {
        readonly Form1 form1Instace = Form1.Instance;
        public List<UserMessage> messages = new List<UserMessage>();
        public string generalChat = "";
        public string notificationText = "";
        public Form2()
        {
            InitializeComponent();
            this.Text = "Чат";
            listUsers.Items.Add("Общий чат");
            listUsers.SelectedIndex = 0;
            loginLabel.Text = form1Instace.login;
            this.FormClosing += Form2Closing;
            Program.SendMessage("getusers/");

            messageTextBox.KeyPress += MessageBox_KeyPress;
        }

        private void MessageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendBtn_Click(sender, e);
            }
        }


        public event EventHandler Form2Closed;

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string message = messageTextBox.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                if (listUsers.SelectedIndex != 0)
                {
                    string selectedUser = listUsers.SelectedItem.ToString();
                    Program.SendMessage("message_for/" + selectedUser + "/" + form1Instace.login + "/(" + DateTime.Now.ToString("HH:mm") + ")  " + form1Instace.login + ": " + message);
                    messageTextBox.Text = string.Empty;
                }
                else
                {
                    Program.SendMessage("message/(" + DateTime.Now.ToString("HH:mm") + ")  " + form1Instace.login + ": " + message);
                    messageTextBox.Text = string.Empty;
                }
            }
        }

        public void UpdateMessage(string login, string message)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].Login == login)
                {
                    var tempUserMessage = messages[i];
                    tempUserMessage.Message = messages[i].Message + (message + Environment.NewLine);
                    messages[i] = tempUserMessage;
                    if (listUsers.InvokeRequired)
                    {
                        listUsers.Invoke((MethodInvoker)delegate
                        {
                            if (listUsers.SelectedIndex != 0)
                            {
                                string selectedUser = listUsers.SelectedItem.ToString();
                                if (login != selectedUser)
                                {
                                    notificationText += message + Environment.NewLine;
                                    DisplayMessage(notificationTextBox, notificationText);
                                }
                            }
                            else
                            {
                                notificationText += message + Environment.NewLine;
                                DisplayMessage(notificationTextBox, notificationText);
                            }
                        });
                    }
                    else
                    {
                        if (listUsers.SelectedIndex != 0)
                        {
                            string selectedUser = listUsers.SelectedItem.ToString();
                            if (login != selectedUser)
                            {
                                notificationText += message + Environment.NewLine;
                                DisplayMessage(notificationTextBox, notificationText);
                            }
                        }
                        else
                        {
                            notificationText += message + Environment.NewLine;
                            DisplayMessage(notificationTextBox, notificationText);
                        }
                    }
                    break;
                }
            }
        }

        public void UpdateMessages()
        {
            if (listUsers.InvokeRequired)
            {
                listUsers.Invoke((MethodInvoker)delegate
                {
                    if (listUsers.SelectedIndex != 0)
                    {
                        string selectedUser = listUsers.SelectedItem.ToString();
                        foreach (UserMessage message in messages)
                        {
                            if (message.Login == selectedUser)
                            {
                                DisplayMessage(messagesTextBox, message.Message);
                            }
                        }
                    }
                    else
                    {
                        DisplayMessage(messagesTextBox, generalChat);
                    }
                });
            }
            else
            {
                if (listUsers.SelectedIndex != 0)
                {
                    string selectedUser = listUsers.SelectedItem.ToString();
                    foreach (UserMessage message in messages)
                    {
                        if (message.Login == selectedUser)
                        {
                            DisplayMessage(messagesTextBox, message.Message);
                        }
                    }
                }
                else
                {
                    DisplayMessage(messagesTextBox, generalChat);
                }
            }
        }

        public void DisplayMessage(TextBox textBox, string message)
        {
            if(textBox.InvokeRequired)
            {
                textBox.Invoke((MethodInvoker)delegate
                {
                    textBox.Text = message;
                });
            }
            else
            {
                textBox.Text = message;
            }
        }

        public void DisplayUser(string login)
        {
            if (listUsers.InvokeRequired)
            {
                listUsers.Invoke((MethodInvoker)delegate
                {
                    listUsers.Items.Add(login);
                });
            }
            else
            {
                listUsers.Items.Add(login);
            }
        }

        public void RemoveUser(string login)
        {
            if (listUsers.InvokeRequired)
            {
                listUsers.Invoke((MethodInvoker)delegate
                {
                    string selectedUser = listUsers.SelectedItem.ToString();

                    if (selectedUser == login)
                    {
                        listUsers.SelectedIndex = 0;
                    }
                    listUsers.Items.Remove(login);
                });
            }
            else
            {
                string selectedUser = listUsers.SelectedItem.ToString();

                if (selectedUser == login)
                {
                    listUsers.SelectedIndex = 0;
                }
                listUsers.Items.Remove(login);
            }
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].Login == login)
                {
                    messages.RemoveAt(i);
                    break;
                }
            }
        }

        private void ListUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMessages();
        }

        private void Form2Closing(object sender, FormClosingEventArgs e)
        {
            Form2Closed?.Invoke(this, EventArgs.Empty);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            notificationText = "";
            DisplayMessage(notificationTextBox, notificationText);
        }
    }
}
