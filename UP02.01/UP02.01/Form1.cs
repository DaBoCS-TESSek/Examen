using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP02._01
{
    public partial class Form1 : Form
    {

        string[] User = new string[2];

        public Form1()
        {
            InitializeComponent();
            User = new string[2] {"Test" , "Оператор"};
        }

        public string[] UserS
        {
            set
            {
                User = new string[value.Length];
                User = value;
                label1.Text = $"{User[0]}\n{User[1]}";
                label1.ForeColor = Color.Black;
                label1.Font = new Font("Times New Roman",14F);
                Clearform();
                CreateForm(User[1]);
            }
            get 
            { 
                return User;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateForm(User[1]);
        }

        public void Clearform() 
        {
            foreach (Button B in buttons)
            {
                Controls.Remove(B);
            }
        }
        Button[] buttons = null;
        public void CreateForm(string role)
        {
            Console.WriteLine($"Role = {role}");
            // 72:135 ------ 300:50 -- 33 + 50

            switch (role)
            {
                case null:
                case "Заказчик": 
                case "Мастер": buttons = new Button[2]; break;
                case "Оператор":
                case "Менеджер": buttons = new Button[4]; break;
            }

            switch (role)
            {
                case null:
                    int x = 72;
                    int y = 135;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i] = new Button();
                        if (i == 0)
                        {
                            buttons[i].Location = new Point(x, y);
                            buttons[i].Text = "Вход";
                        }
                        else
                        {
                            buttons[i].Location = new Point(x, y);
                            buttons[i].Text = "Регистрация";

                        }
                        y += 83;
                        buttons[i].Size = new Size(300, 50);
                        buttons[i].BackColor = Color.SteelBlue;
                        buttons[i].ForeColor = Color.Black;

                        buttons[i].Click += new EventHandler(ButtonClick);

                        Controls.Add(buttons[i]);
                    }
                    break;
                case "Заказчик":
                case "Мастер":
                    x = 72;
                    y = 135;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i] = new Button();
                        if (i == 0)
                        {
                            buttons[i].Location = new Point(x, y);
                        }
                        else
                        {
                            buttons[i].Location = new Point(x, y);
                        }

                        if (i == 0) buttons[i].Text = "Личные данные";
                        if (i == 1) buttons[i].Text = "Заявки";
                        y += 83;
                        buttons[i].Size = new Size(300, 50);
                        buttons[i].BackColor = Color.SteelBlue;
                        buttons[i].ForeColor = Color.Black;

                        buttons[i].Click += new EventHandler(ButtonClick);

                        Controls.Add(buttons[i]);
                    }
                    break;
                // до клиенты
                case "Оператор":
                case "Менеджер":

                    x = 72;
                    y = 135;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i] = new Button();
                        if (i == 0)
                        {
                            buttons[i].Location = new Point(x, y);
                        }
                        else
                        {
                            buttons[i].Location = new Point(x, y);
                        }

                        if (i == 0) buttons[i].Text = "Личные данные";
                        if (i == 1) buttons[i].Text = "Заявки";
                        if (i == 2) buttons[i].Text = "Мастера";
                        if (i == 3) buttons[i].Text = "Все пользователи";

                        y += 83;
                        buttons[i].Size = new Size(300, 50);
                        buttons[i].BackColor = Color.SteelBlue;
                        buttons[i].ForeColor = Color.Black;

                        buttons[i].Click += new EventHandler(ButtonClick);

                        Controls.Add(buttons[i]);
                    }
                    break;
            }
        }
        public void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Вход")
            {
                Authorization auth = new Authorization();
                auth.Owner = this;
                auth.ShowDialog();
            }
            if (button.Text == "Регистрация")
            {
                Registration registration = new Registration();
                registration.Owner = this;
                registration.ShowDialog();
            }
            if (button.Text == "Личные данные")
            {

            }
            if (button.Text == "Заявки")
            {

            }
            if (button.Text == "Мастера")
            {

            }
            if (button.Text == "Все пользователи")
            {
                AllUsers allUsers = new AllUsers();
                allUsers.Owner = this;
                allUsers.ShowDialog();
            }
        }
    }
}
