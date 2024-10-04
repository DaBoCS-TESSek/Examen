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
    public partial class Authorization : Form
    {

        private SQL_Connect SQL_Connect = new SQL_Connect();
        Form1 MainForm;

        public Authorization()
        {
            InitializeComponent();
        }
        private void Authorization_Load(object sender, EventArgs e)
        {
            MainForm = (Form1)Owner;
            button1.Enabled = false;
        }

        private void textBoxs_Enter(object sender, EventArgs e)
        {
            if (sender == textBox1)
                textBox1.Clear();
            if (sender == textBox2)
                textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Pass = textBox2.Text;

            string query = $"select * from users where login = '{Login}' and pass = '{Pass}'";

            if (SQL_Connect.Get_data(query) != null)
            {
                MessageBox.Show("Успех");
                query = $"select FIO, roli.name_rol from users inner join roli on users.id_rol = roli.id_rol where login = '{Login}' and pass = '{Pass}';";
                List<object[]> Data = SQL_Connect.Get_data(query);

                string[] UserInfo = new string[2];

                UserInfo[0] = Data[0][0].ToString();

                UserInfo[1] = Data[0][1].ToString();

                foreach (string s in UserInfo) Console.WriteLine(s);

                MainForm.UserS = UserInfo;

                this.Close();
            }
            else
            {
                MessageBox.Show("Провал");
            }

        }

        private void textBoxs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Registration Reg = new Registration();
            this.Close();
            Reg.ShowDialog();
            
        }
    }
}
