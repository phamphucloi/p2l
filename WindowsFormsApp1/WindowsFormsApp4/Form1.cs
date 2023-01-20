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

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private async void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["phamphucloi"].ConnectionString;
            command.Connection = con;
            command.CommandText = "SelectAllSubject";
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);

            bindingSource1.DataSource = ds.Tables[0].DefaultView;
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            command.CommandText = "InsertSubject";
            command.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(txtNameCredits.Text) || string.IsNullOrEmpty(txtNameCredits.Text))
            {
                MessageBox.Show("Please, write all field", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            command.Parameters.Add("@name", txtNameSubject.Text);
            command.Parameters.Add("@credit", txtNameCredits.Text);
            con.Open();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Insert-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindingSource1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message);
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
                txtNameCredits.DataBindings.Clear();
                txtNameSubject.DataBindings.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
