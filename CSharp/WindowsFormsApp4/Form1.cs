using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //kết nốp tới sql
        SqlConnection con = new SqlConnection();
        //thực hiện ICRUD
        SqlCommand command = new SqlCommand();
        //tránh phân mảnh dữ liệu
        SqlDataAdapter adapter = new SqlDataAdapter();
        //xét dữ liệu vào bảng
        DataSet ds = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.studentTableAdapter.Fill(this.pPL_WFDataSet.Student);
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ppl"].ConnectionString;
            command.Connection = con;
            command.CommandText = "select * from Student";
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;
            adapter.Fill(ds);

        }
    }
}
