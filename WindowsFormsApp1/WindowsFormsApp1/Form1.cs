using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ploi"].ConnectionString;
            cmd.Connection = con;
            cmd.CommandText = "GetAllStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            dataGrid.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
