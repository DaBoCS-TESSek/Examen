using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP02._01
{
    public partial class Registration : Form
    {
        private SQL_Connect SQL_Connect = new SQL_Connect();
        Form1 MainForm;

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            MainForm = (Form1)Owner;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FIO = textBox3.Text;
            string tel = maskedTextBox1.Text;
            string login = textBox1.Text;
            string pass = textBox2.Text;

            string query = $"insert into users values ( N'{FIO}', '{tel}', N'{login}', N'{pass}', 4);";


            if (SQL_Connect.Get_data($"select * from users where FIO = '{FIO}' or login = '{login}';") == null)
            {
                SQL_Connect.Send_data(query);

                if (SQL_Connect.Get_data($"select * from users where FIO = N'{FIO}';") != null)
                {
                    MainForm.UserS = new string[] { FIO, "Заказчик" };
                    this.Close();
                }
                else
                    MessageBox.Show("Что-то пошло не так");
            }
            else
                MessageBox.Show("Такой пользователь уже существует");
        }

        private void textBoxs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "")
                button1.Enabled = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (sender == textBox1)
                textBox1.Clear();
            if (sender == textBox2)
                textBox2.Clear();
            if (sender == textBox3)
                textBox3.Clear();
            if (sender == maskedTextBox1)
                maskedTextBox1.Clear();
        }
    }
}
