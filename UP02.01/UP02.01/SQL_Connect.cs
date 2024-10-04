using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace UP02._01
{
    public class SQL_Connect
    {
        private string _Connection_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\429195-27\\Downloads\\экзамен.mdf\";Integrated Security=True;Connect Timeout=30;";
        //private string _Connection_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\Учебная практика\\5е задание\\БД.mdf\";Integrated Security=True;Connect Timeout=30";
        SqlConnection _connection;

        // Проверка на додключение к БД
        public bool Is_connecting()
        {
            using (_connection = new SqlConnection(_Connection_string))
            {
                try
                {
                    _connection.Open();
                    Console.WriteLine("Подключение установлено");
                    _connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
            return false;
        }
        // Получение данных из БД
        public List<Object[]> Get_data(string query)
        {
            List<Object[]> Data = new List<Object[]>();
            SqlDataReader reader = null;
            _connection = new SqlConnection(_Connection_string);

            if (Is_connecting())
            {
                using (_connection = new SqlConnection(_Connection_string))
                {
                    _connection.Open();

                    using (SqlCommand command = new SqlCommand(query, _connection))
                    {
                        reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var row = new Object[reader.FieldCount];

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[i] = reader.GetValue(i);
                                }
                                Data.Add(row);
                            }
                            _connection.Close();
                            return Data;
                        }
                    }
                }
            }
            return null;
        }
        // Отправка данных
        public void Send_data(string query)
        {
            if (Is_connecting())
            {
                try
                {
                    using (_connection = new SqlConnection(_Connection_string))
                    {
                        _connection.Open();

                        SqlCommand command = new SqlCommand(query, _connection);
                        command.ExecuteNonQuery();
                        _connection.Close();
                        MessageBox.Show("Данные успешно изменены");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void ToPrint(List<object[]> data)
        {
            if (data != null)
            {
                foreach (object[] obj in data)
                {
                    for (int i = 0; i < obj.Length; i++)
                    {
                        Console.Write(obj[i] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Дата пуста");
        }



    }
}
