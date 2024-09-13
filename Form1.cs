using System;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Вход";
            StartPosition = FormStartPosition.CenterScreen; // Устанавливаем центральное положение формы
            instance = this;
            this.FormClosing += Form1Closing;

            loginBox.KeyPress += LoginBox_KeyPress;
        }

        private void LoginBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginBtn_Click(sender, e);
            }
        }

        public static Form1 Instance
        {
            get { return instance; }
        }

        public Form2 form2;

        public string login;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            login = loginBox.Text;

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Пожалуйста, введите логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (login.Contains("/"))
            {
                MessageBox.Show("Логин содержит запрещенный символ '/'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Program.SendMessage("login/" + login);
        }

        public void CreateForm2()
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                form2 = new Form2();
                form2.Form2Closed += Form2_FormClosed;
                this.Hide();
                form2.Show();
            });
        }

        private void Form1Closing(object sender, FormClosingEventArgs e)
        {
            Program.SendMessage("disconnect/");
            if (Program.receiveThread != null && Program.receiveThread.IsAlive)
            {
                Program.receiveThread.Abort();
            }

            Program.networkStream?.Close();

            Program.tcpClient?.Close();
        }

        private void Form2_FormClosed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
