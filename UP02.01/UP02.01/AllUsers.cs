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
    public partial class AllUsers : Form
    {
        SQL_Connect SQL_Connect = new SQL_Connect();
        DataToTable dataTable = new DataToTable();

        public AllUsers()
        {
            InitializeComponent();
        }

        public void CreateTable()
        {
            dataGridView1.Rows.Clear();
            string query = "select id_user, FIO, phone, login, pass, name_rol from users inner join roli on users.id_rol = roli.id_rol;";
            List<object[]> Users = SQL_Connect.Get_data(query);
            dataTable.DataToDGV(dataGridView1, Users);
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            CreateTable();

            string query = "select name_rol from roli;";
            List<object[]> roli = SQL_Connect.Get_data(query);
            dataTable.DataToCB(comboBox1, roli);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox1.Text = dataGridView1[1,e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            textBox4.Text = dataGridView1[4, e.RowIndex].Value.ToString();

            DataGridViewRow selectedrow = dataGridView1.Rows[e.RowIndex];

            comboBox1.SelectedIndex = comboBox1.FindStringExact(selectedrow.Cells["Column6"].Value.ToString());
        }

        private void textBoxs_Enter(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            
            textBox = (TextBox)sender;

            textBox.Clear();

            textBox.ForeColor = Color.Black;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TB = new TextBox();
            DataGridView DGV = new DataGridView();

            TB = textBox5;
            DGV = dataGridView1;



            string Find = TB.Text;
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                DGV.Rows[i].Selected = false;
                for (int j = 0; j < DGV.Columns.Count; j++)
                {
                    if (DGV.Rows[i].Cells[j].Value.ToString().Contains(Find))
                    {
                        DGV.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            TextBox TB = new TextBox();
            TB = textBox5;
            TB.Text = "Поиск";

            TB.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = $"update users set FIO = N'{textBox1.Text}', phone = N'{textBox2.Text}', login = N'{textBox3.Text}', pass = N'{textBox4.Text}', id_rol = {comboBox1.SelectedIndex + 1} where id_user = {Convert.ToInt32(label1.Text)}";
            SQL_Connect.Send_data(query);

            CreateTable();
        }
    }
}
