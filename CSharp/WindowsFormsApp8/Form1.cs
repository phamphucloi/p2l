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
        using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                //dataGridView return list, so .ToList() from IQueryable convert type to Ienumerable 

                //dataGridView1.DataSource = await stu.Students.Select(st => new
                //{
                //    st.Id, st.FirstName, st.LastName, st.Gender, st.DoB
                //}).ToListAsync();

                await LoadDataBase(stu);

                txtId.DataBindings.Add("Text", bindingSource1, "Id");
                txtFname.DataBindings.Add("Text", bindingSource1, "FirstName");
                txtLname.DataBindings.Add("Text", bindingSource1, "LastName");
                ckBox.DataBindings.Add("Checked", bindingSource1, "Gender");
                dateChoose.DataBindings.Add("Value", bindingSource1, "DoB");
            }
        }

        private async Task LoadDataBase(PPL_WFEntities stu)
        {
            bindingSource1.DataSource = await stu.Students.ToListAsync();
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                Student st = new Student();
                foreach (var i in stu.Students)
                {
                    if (i.FirstName==txtFname.Text)
                    {
                        MessageBox.Show("Không được trùng tên.");
                        return;
                    }
                }
                st.FirstName = txtFname.Text;
                st.LastName= txtLname.Text;
                st.Gender = (ckBox.Checked) ? true : false;
                st.DoB = dateChoose.Value;
                stu.Students.Add(st);

                await stu.SaveChangesAsync();
                await LoadDataBase(stu);
                MessageBox.Show("Thêm thành công.");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                int id = Convert.ToInt16(txtId.Text);
                Student ob = await stu.Students.FirstOrDefaultAsync(stud=>stud.Id==id);

                if (ob !=null)
                {
                    ob.FirstName = txtFname.Text;
                    ob.LastName = txtLname.Text;
                    ob.Gender = (ckBox.Checked);
                    ob.DoB = dateChoose.Value;
                }
                await stu.SaveChangesAsync();
                await LoadDataBase(stu);
                MessageBox.Show("Sửa thành công.");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (PPL_WFEntities stu = new PPL_WFEntities())
            {
                int id = Convert.ToInt32(txtId.Text);

                foreach (var i in stu.Students)
                {
                    if (i.Id==id)
                    {
                        stu.Students.Remove(i);
                    }
                }
                await stu.SaveChangesAsync();
                await LoadDataBase(stu);
                MessageBox.Show("Xóa thành công.");
            }


        }
    }
}
