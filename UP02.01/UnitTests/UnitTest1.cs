using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UP02._01;

namespace UnitTests
{

    [TestClass]
    public class UnitTest1
    {
        SQL_Connect SQL_Connect = new SQL_Connect();

        [TestMethod]
        public void Is_connecting()
        {
            bool experted = true;

            bool actual = SQL_Connect.Is_connecting();

            Assert.AreEqual(experted, actual);
        }

        [TestMethod]
        public void Get_data()
        {
            int experted_Data = 3;

            string query = "Select Count(*) from statuss;";
            int actual_Data = Convert.ToInt32(SQL_Connect.Get_data(query)[0][0]);


            SQL_Connect.ToPrint(SQL_Connect.Get_data("Select * from statuss"));
            Assert.AreEqual(experted_Data, actual_Data);
        }

        [TestMethod]
        public void Set_data()
        {
            int experted = 4;

            string query = "insert into statuss values ('1234');";
            SQL_Connect.Send_data(query);

            int actual = Convert.ToInt32(SQL_Connect.Get_data("Select Count(*) from statuss;")[0][0]);


            SQL_Connect.Send_data("delete from statuss where name_status = '1234';");

            Assert.AreEqual(experted, actual);
        }
    }
}
