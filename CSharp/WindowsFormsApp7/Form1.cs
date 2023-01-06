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

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //object still survice
            //PPL_WFEntities ef = new PPL_WFEntities();
            //    dataGridView1.DataSource = ef.Students.ToList();

            //object died
            //using (PPL_WFEntities ef = new PPL_WFEntities())
            //{
            //    dataGridView1.DataSource = ef.Students.ToList();
            //}

            using (PPL_WFEntities ef = new PPL_WFEntities())
            {
                //lấy ra những thứ cần => query syntax;
                //dataGridView1.DataSource = ef.Students.Select(stu => new
                //{
                //    stu.Id, stu.FirstName, stu.LastName, stu.DoB
                //}).ToList();

                bindingSource1.DataSource = await ef.Students.ToListAsync();
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView1.DataSource = bindingSource1;


                txtId.DataBindings.Add("Text",bindingSource1, "Id");
                txtFname.DataBindings.Add("Text", bindingSource1, "FirstName");
                txtLname.DataBindings.Add("Text", bindingSource1, "LastName");
                ckBox.DataBindings.Add("Checked", bindingSource1, "Gender");
                dateChoose.DataBindings.Add("Value", bindingSource1, "DoB");
            }
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities ef = new PPL_WFEntities())
            {
                int id = Convert.ToInt16(txtId.Text);
                var obj = await ef.Students.FirstOrDefaultAsync(i=>i.Id==id);

                if (obj != null)
                {
                    obj.FirstName = txtFname.Text;
                    obj.LastName = txtLname.Text;
                    obj.Gender = ckBox.Checked;
                    obj.DoB = dateChoose.Value;
                }

                //sửa xong hết thì update về databasqe
                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.ToListAsync();

                MessageBox.Show("Update-SuccessFully");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities ef = new PPL_WFEntities())
            {
                var stu = new Student();
                stu.FirstName = txtFname.Text;
                stu.LastName = txtLname.Text;
                stu.Gender = ckBox.Checked;
                stu.DoB = dateChoose.Value;

                ef.Students.Add(stu);
                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.ToListAsync();
                MessageBox.Show("Add-Successfully");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities ef = new PPL_WFEntities())
            {
                int id = Convert.ToInt16(txtId.Text);
                foreach (var stu in ef.Students)
                {
                    if (stu.Id==id)
                    {
                        ef.Students.Remove(stu);
                    }
                }
                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.ToListAsync();

                //ef.Students.RemoveRange(st => ef.Students.Where(st2 => st2.Id == id).ToListAsync());

                MessageBox.Show("Delete-SuccessFully");
            }
        }
    }
}
