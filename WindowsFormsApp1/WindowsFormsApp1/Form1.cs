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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ploi"].ConnectionString;
                con.Open();
                cmd.Connection = con;
                if (string.IsNullOrEmpty(namePro.Text))
                {
                    MessageBox.Show("Please enter name to insert", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmd.CommandText = "Insert into Product([name]) Values(@name)";
                cmd.Parameters.AddWithValue("@name", namePro.Text);
                cmd.CommandType = CommandType.Text;
                MessageBox.Show("Thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //dataGrid.DataSource = ds.Tables[0].DefaultView;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try{
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ploi"].ConnectionString;
                cmd.Connection = con;
                cmd.CommandText = "select * from Product";
                cmd.CommandType = CommandType.Text;
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                dataGrid.DataSource = ds.Tables[0].DefaultView;
            }catch (Exception ev)
            {
                MessageBox.Show(ev.Message,"THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ploi"].ConnectionString;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update Product set [name]=@name where id=@id";
                if (string.IsNullOrEmpty(id.Text))
                {
                    MessageBox.Show("Please enter id", "Information", MessageBoxButtons.OK, MessageBoxIcon.
                        Error);
                    return;
                }

                if (string.IsNullOrEmpty(namePro.Text))
                {
                    MessageBox.Show("Please enter name to update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                cmd.Parameters.AddWithValue("@name", namePro.Text);
                cmd.CommandType = CommandType.Text;
                MessageBox.Show("Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ploi"].ConnectionString;
                cmd.Connection = con;
                cmd.CommandText = "select * from Product";
                cmd.CommandType = CommandType.Text;
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                dataGrid.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchChanged(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ploi"].ConnectionString;
                cmd.Connection = con;
                cmd.CommandText = "select * from Product where [name] like '%@name%'";
                cmd.Parameters.AddWithValue("@name", search.Text);
                cmd.CommandType = CommandType.Text;
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                dataGrid.DataSource = ds.Tables[0].DefaultView;
            }
            catch(Exception ev)
            {
                MessageBox.Show(ev.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
