using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp9.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pHAMPHUCLOIDataSet2.tblStudent' table. You can move, or remove it, as needed.
            this.tblStudentTableAdapter.Fill(this.pHAMPHUCLOIDataSet2.tblStudent);
            //using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            //{
            //    await LoadData(stu);

            //    foreach (var i in stu.tblSubjects)
            //    {
            //        cbSubject.Items.Add(i.deptName);
            //    }

            //    txtId.DataBindings.Add("Text", bindingSource1, "stuId");
            //    txtName.DataBindings.Add("Text", bindingSource1, "stuName");
            //    txtEmail.DataBindings.Add("Text", bindingSource1, "stuEmail");
            //    txtPhone.DataBindings.Add("Text", bindingSource1, "stuPhone");
            //    cbSubject.DataBindings.Add("Text", bindingSource1, "deptId");
            //}
            con.ConnectionString = ConfigurationManager.ConnectionStrings["phamphucloi"].ConnectionString;

            command.Connection = con;

            command.CommandText = "select * from tblStudent";

            command.CommandType = CommandType.Text;

            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private async Task LoadData(PHAMPHUCLOIEntities stu)
        {
            bindingSource1.DataSource = await stu.tblStudents.Select(st =>new
            {
                st.stuId, st.stuName, st.stuPass, st.stuPhone, st.stuEmail, st.deptId
            }).ToListAsync();
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "Password is your phone number.";
            txtPhone.Text = "";
            txtName.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            cbSubject.DataBindings.Clear();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(cbSubject.Text))
                {
                    MessageBox.Show(this,"Please enter all field.","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                tblStudent st = new tblStudent();
                st.stuName = txtName.Text;
                st.stuPhone = txtPhone.Text;
                st.stuPass = txtPhone.Text;
                st.stuEmail = txtEmail.Text;
                st.deptId = Convert.ToInt16(cbSubject.Text);
                stu.tblStudents.Add(st);
                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show(this,"Insert-Succesfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(txtId.Text);

                var ob = await stu.tblStudents.FirstOrDefaultAsync(st => st.stuId == id);

                if (ob != null)
                {
                    ob.stuName = txtName.Text;
                    ob.stuEmail= txtEmail.Text;
                    ob.stuPass= txtPhone.Text;
                    ob.stuPhone= txtPhone.Text;
                    foreach (var i in stu.tblSubjects)
                    {
                        if (i.deptName == cbSubject.Text)
                        {
                            ob.deptId = i.deptId;
                        }
                    }
                }

                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show(this, "Update-Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(txtId.Text);

                foreach (var i in stu.tblStudents)
                {
                    if (i.stuId == id)
                    {
                        stu.tblStudents.Remove(i);
                    }
                }
                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show(this, "Delete-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"stuName like '%{txtSearch.Text}%'";
            //this.dataGridView1.DataSource = DataTable.DefaultView;
            //ds.Tables[0].DefaultView.RowFilter = $"stuName LIKE '%{txtSearch.Text}%'";

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"stuName like '%{txtSearch.Text}%'";
            DataTable dt = new DataTable();
            DataView dv = dt.DefaultView;
            dv.RowFilter = $"stuName like '%{txtSearch.Text}%'";
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbSubject.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
    }
}
