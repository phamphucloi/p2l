using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Helper;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                await LoadData(stu);

                txtId.DataBindings.Add("Text", bindingSource1, "Id");
                txtFName.DataBindings.Add("Text", bindingSource1, "FirstName");
                txtLName.DataBindings.Add("Text", bindingSource1, "LastName");
                ckBox.DataBindings.Add("Checked", bindingSource1, "Gender");
                dateChoose.DataBindings.Add("Value", bindingSource1, "DoB");
            }
        }

        private async Task LoadData(PPL_WFEntities stu)
        {
            bindingSource1.DataSource = await stu.Students.ToListAsync();
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                Student st = new Student();
                st.FirstName = txtFName.Text;
                st.LastName = txtLName.Text;
                st.Gender = ckBox.Checked;
                st.DoB = dateChoose.Value;
                stu.Students.Add(st);
                

                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show("Insert-Successfully");

            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                int id = Validation<int>.CheckRegex();

                Student st = await stu.Students.FirstOrDefaultAsync(i=>i.Id==id);

                if (st!=null)
                {
                    st.FirstName = txtFName.Text;
                    st.LastName = txtLName.Text;
                    st.Gender = ckBox.Checked;
                    st.DoB = dateChoose.Value;
                }

                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show("Update-Successfully");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                int id = Validation<int>.CheckRegex();

                foreach (var i in stu.Students)
                {
                    if (i.Id == id)
                    {
                        stu.Students.Remove(i);
                    }
                }

                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show("Delete-Successfully");
            }
        }

            SqlConnection con = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                foreach (var i in stu.Students)
                {
                    ; /*= $" FirstName like'%{txtSearch.Text}%'"; */
                }
            }
        }
    }
}
