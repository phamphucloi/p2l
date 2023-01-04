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

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter(); 
        DataSet ds = new DataSet();


        private void Form2_Load(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.pPL_WF2DataSet.Student);
            con.ConnectionString = ConfigurationManager.ConnectionStrings["loi"].ConnectionString;
            command.Connection = con;
            command.CommandText = "select * from Student";
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGrid.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
