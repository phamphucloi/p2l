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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //connect to database
        SqlConnection con = new SqlConnection();

        //perform statements insert, delete, update, select
        SqlCommand command = new SqlCommand();

        //tránh dữ liệu bị phân mảnh
        SqlDataAdapter adapter = new SqlDataAdapter();

        //tổng hợp và ghi dữ liệu thành cột
        DataSet ds = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["phamphucloi"].ConnectionString;

            command.Connection = con;

            command.CommandText = "GetAllStudents";

            command.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);

            //bindingSource1.DataSource = ds.Tables[0];
            //dataGrid.DataSource = bindingSource1;
            //bindingNavigator1.BindingSource = bindingSource1;

            //textBox2.DataBindings.Add("Text", bindingSource1, "Id", true, DataSourceUpdateMode.OnPropertyChanged);

            //txtFirstName.DataBindings.Add("Text", bindingSource1, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
            ////dataGrid.DataSource = ds.Tables[1].DefaultView;
            //txtLastName.DataBindings.Add("Text", bindingSource1, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);

            //checkBox1.DataBindings.Add("Checked", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);

            //dtp.DataBindings.Add("Value", bindingSource1, "DoB", true, DataSourceUpdateMode.OnPropertyChanged);
























            bindingSource1.DataSource = ds.Tables[0];
            dataGrid.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            txtfname.DataBindings.Add("Text", bindingSource1,"FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtlname.DataBindings.Add("Text", bindingSource1, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
            ckBox.DataBindings.Add("checked", bindingSource1,"Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            dateChoose.DataBindings.Add("Value", bindingSource1, "DoB" , true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text",bindingSource1, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            command.CommandText = "UpdateStudent";
            command.CommandType = CommandType.StoredProcedure;
            //
            command.Parameters.AddWithValue("@fname",txtFirstName.Text);
            command.Parameters.AddWithValue("@lname", txtLastName.Text);
            command.Parameters.AddWithValue("@gender", checkBox1.Checked);
            command.Parameters.AddWithValue("@dob", dtp.Value);
            command.Parameters.AddWithValue("@id", textBox2.Text);
            con.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully");
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message,"Error",MessageBoxButtons.OK);
            }
//            finally 
//            { 
//                con.Close(); 
//                command.Parameters.Clear();
//                textBox2.DataBindings.Clear();
//                txtFirstName.DataBindings.Clear();
//                txtLastName.DataBindings.Clear();
//                checkBox1.DataBindings.Clear();
//                dtp.DataBindings.Clear();
//                LoadData();
//0           }
        }


        private void Form1_TextChanged(object sender, EventArgs e)
        {
            //ds.Tables[0].DefautView = select * from student.
            //RowFilter = where => firstname like '%...%'.
            ds.Tables[0].DefaultView.RowFilter = $" FirstName like '%{toolStripTextBox1.Text}%'";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
             ds.Tables[0].DefaultView.RowFilter = $"FirstName like '%{txtSearch.Text}%' OR LastName like '%{txtSearch.Text}%'";
        }

        private void btnUpdateAdapter_Click(object sender, EventArgs e)
        {
            //bindingSource1.EndEdit();
            //SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            //builder.GetUpdateCommand();
            //try
            //{
            //    adapter.Update(ds.Tables[0]);
            //}
            //catch (Exception ev)
            //{
            //    MessageBox.Show(ev.Message, "Error", MessageBoxButtons.OK);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            builder.GetUpdateCommand();
            try
            {
                adapter.Update(ds.Tables[0]);
            }catch(Exception ev)
            {
                MessageBox.Show(ev.Message, "Error", MessageBoxButtons.OK);
            }
            finally { 
                builder.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            command.CommandText = "InsetStudent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@fname", txtfname.Text);
            command.Parameters.AddWithValue("@lname", txtlname.Text);
            command.Parameters.AddWithValue("@gen", (ckBox.Checked)?true:false);
            command.Parameters.AddWithValue("@dob", dateChoose.Value);
            con.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully");
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message, "Error", MessageBoxButtons.OK);
            }
            finally 
            { 
                con.Close(); 
                command.Parameters.Clear();
                txtfname.DataBindings.Clear();
                txtlname.DataBindings.Clear();
                ckBox.DataBindings.Clear();
                dateChoose.DataBindings.Clear();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            command.CommandText = "DeleteStudent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", textBox2.Text);
            con.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Delete-Successfull");
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message, "Error", MessageBoxButtons.OK);
            }
            finally 
            { 
                con.Close();
                command.Parameters.Clear();
                txtfname.DataBindings.Clear();
                txtlname.DataBindings.Clear();
                ckBox.DataBindings.Clear();
                dateChoose.DataBindings.Clear();
                textBox2.DataBindings.Clear();
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            SqlCommandBuilder build = new SqlCommandBuilder(adapter);
            build.GetUpdateCommand();
            try
            {
                adapter.Update(ds.Tables[0]);
                MessageBox.Show("Update - Successfully");
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message);
            }
            finally
            {
                adapter.Dispose();
                txtfname.DataBindings.Clear();
                txtlname.DataBindings.Clear();
                ckBox.DataBindings.Clear();
                dateChoose.DataBindings.Clear();
                textBox2.DataBindings.Clear();
                LoadData();
            }
        }

    }
}
