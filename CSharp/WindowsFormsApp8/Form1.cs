using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp8.Model;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
        using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                //dataGridView return list, so .ToList() from IQueryable convert type to Ienumerable 

                //dataGridView1.DataSource = await stu.Students.Select(st => new
                //{
                //    st.Id, st.FirstName, st.LastName, st.Gender, st.DoB
                //}).ToListAsync();

                await LoadDataBase(stu);

                //txtId.DataBindings.Add("Text", bindingSource1, "Id");
                //txtFname.DataBindings.Add("Text", bindingSource1, "FirstName");
                //txtLname.DataBindings.Add("Text", bindingSource1, "LastName");
                //ckBox.DataBindings.Add("Checked", bindingSource1, "Gender");
                //dateChoose.DataBindings.Add("Value", bindingSource1, "DoB");
            }
        }

        private async Task LoadDataBase(PHAMPHUCLOIEntities stu)
        {
            bindingSource1.DataSource = await stu.tblStudents.Select(st => new
            {
                st.stuGender, st.stuName
            }).ToListAsync();
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
