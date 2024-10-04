using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP02._01
{
    public class DataToTable
    {
        public void DataToDGV(DataGridView DGV, List<object[]> DATA)
        {
            foreach (object[] item in DATA)
            {
                DGV.Rows.Add(item);
            }
        }
        public void DataToCB(ComboBox CB, List<object[]> DATA)
        {
            foreach (object[] item in DATA)
            {
                CB.Items.Add(item[0]);
            }
        }
    }
}
