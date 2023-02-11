using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp12.Model;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }



        private static bool IsNumber(string val)
        {
            if (val != "") return Regex.IsMatch(val, @"^[0-9]\d*\.?[0]*$");
            else return true;
        }

        private static bool IsEmail(string email)
        {
            if (email != "") return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            else return true;
        }

        private static bool IsName(string name)
        {
            if (name != "") return Regex.IsMatch(name, @"^[a-zA-Z]*$");
            else return true;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                await LoadData(stu);

                this.cbCouIdExam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

                this.cBDeptNameSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

                this.cbStuIdExam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }

        }

        private async Task LoadData4(PHAMPHUCLOIEntities1 stu)
        {
            bindingSource4.DataSource = await stu.tblCourses.Select(co => new
            {
                co.couId,
                co.couName,
                co.couSemester
            }).ToListAsync();
            dataGridView4.DataSource = bindingSource4;
            bindingNavigator4.BindingSource = bindingSource4;

            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Name";
            dataGridView4.Columns[2].HeaderText = "Semester";
        }

        private async Task LoadData3(PHAMPHUCLOIEntities1 stu)
        {
            bindingSource3.DataSource = await stu.tblExams.Select(ex => new
            {
                ex.examId,
                ex.examName,
                ex.examMark,
                ex.examDate,
                ex.stuId,
                ex.couId
            }).ToListAsync();
            dataGridView3.DataSource = bindingSource3;
            bindingNavigator3.BindingSource = bindingSource3;

            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Name";
            dataGridView3.Columns[2].HeaderText = "Mark";
            dataGridView3.Columns[3].HeaderText = "Date";
            dataGridView3.Columns[4].HeaderText = "Id Student";
            dataGridView3.Columns[5].HeaderText = "Id Course";
        }

        private async Task LoadData2(PHAMPHUCLOIEntities1 stu)
        {
                bindingSource2.DataSource = await stu.tblStudents.Select(st => new
                {

                    st.stuId,
                    st.stuName,
                    st.stuPhone,
                    st.stuEmail,
                    st.stuGender,
                    st.deptId
                }).ToListAsync();
            dataGridView2.DataSource = bindingSource2;
            bindingNavigator2.BindingSource = bindingSource2;

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Name";
            dataGridView2.Columns[2].HeaderText = "Phone";
            dataGridView2.Columns[3].HeaderText = "Email";
            dataGridView2.Columns[4].HeaderText = "Gender";
            dataGridView2.Columns[5].HeaderText = "Id Subject";
        }

        private async Task LoadData(PHAMPHUCLOIEntities1 stu)
        {
            bindingSource1.DataSource = await stu.tblSubjects.Select(st => new
            {
                st.deptId,
                st.deptName,
                st.deptCredits
            }).ToListAsync();
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Credits";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeptNameSubject.Text) || string.IsNullOrEmpty(txtCredits.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống các field.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsName(txtDeptNameSubject.Text) != true)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ,tên chỉ chứa kí tự.", "Thông báo");
                txtDeptNameSubject.Text = "";
                return;
            }

            if (IsNumber(txtCredits.Text) != true)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ,tín chỉ chỉ chứa số.", "Thông báo");
                txtCredits.Text = "";
                return;
            }

            if (txtDeptNameSubject.Text.Length >= 30)
            {
                MessageBox.Show(this, "Tên không được vượt quá 30 kí tự.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt16(txtCredits.Text)>10)
            {
                MessageBox.Show(this, "Số tín chỉ vượt quá số lượng.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {

                foreach (var i in stu.tblSubjects)
                {
                    if (i.deptName == txtDeptNameSubject.Text)
                    {
                        MessageBox.Show(this, "Đã tồn tại môn học này.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                tblSubject sub = new tblSubject();
                sub.deptName = txtDeptNameSubject.Text;
                sub.deptCredits = Convert.ToInt16(txtCredits.Text);

                stu.tblSubjects.Add(sub);
                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show(this, "Add-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeptNameSubject.Text) && string.IsNullOrEmpty(txtCredits.Text) && string.IsNullOrEmpty(txtIdSub.Text))
            {
                MessageBox.Show(this, "Đã làm trống các ô.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    txtDeptNameSubject.Text = "";
                    txtCredits.Text = "";
                    txtIdSub.Text = "";
                }
                catch (Exception ev)
                {

                }
                finally
                {
                    txtDeptNameSubject.DataBindings.Clear();
                    txtCredits.DataBindings.Clear();
                    txtIdSub.DataBindings.Clear();
                }
            }
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(txtCredits.Text)>10)
            {
                MessageBox.Show(this, "Vượt quá số lượng cho phép.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                if (string.IsNullOrEmpty(txtIdSub.Text) || string.IsNullOrEmpty(txtDeptNameSubject.Text) || string.IsNullOrEmpty(txtCredits.Text))
                {
                    MessageBox.Show(this, "Không được bỏ trống các field.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int id = Convert.ToInt16(txtIdSub.Text);

                tblSubject sub = await stu.tblSubjects.FirstOrDefaultAsync(st => st.deptId == id);
                if (sub != null)
                {
                    sub.deptName = txtDeptNameSubject.Text;
                    sub.deptCredits = Convert.ToInt16(txtCredits.Text);
                }
                await stu.SaveChangesAsync();
                await LoadData(stu);
                MessageBox.Show(this, "Update-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cbDeptId_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt32(txtIdSub.Text);

                foreach (var i in stu.tblSubjects)
                {
                    if (i.deptId == id)
                    {
                        txtDeptNameSubject.Text = i.deptName;
                        txtCredits.Text = i.deptCredits.ToString();
                    }
                }
                await stu.SaveChangesAsync();
                await LoadData(stu);
            }
        }

        private async void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdSub.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống trường Id.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt32(txtIdSub.Text);

                DialogResult rs = MessageBox.Show(this, "Bạn có chắc sẽ xóa chứ ??", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (rs == DialogResult.OK)
                {
                    foreach (var i in stu.tblSubjects)
                    {
                        foreach (var j in stu.tblStudents)
                        {
                            //j.deptId != i.deptId && j.deptId != id
                            if (id == i.deptId && id != j.deptId)
                            {
                                stu.tblSubjects.Remove(i);
                            }

                            if (j.deptId == id)
                            {
                                MessageBox.Show(this, "Không được xóa môn này.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    await stu.SaveChangesAsync();
                    await LoadData(stu);
                    MessageBox.Show(this, "Delete-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Đã hủy tác vụ thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private async void btnInsertStu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNameStu.Text) || string.IsNullOrEmpty(txtEmailStu.Text) || string.IsNullOrEmpty(txtPhoneStu.Text) || cBDeptNameSub.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Cần điền đẩy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (IsName(txtNameStu.Text) != true)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ,tên chỉ chứa kí tự.", "Thông báo");
                txtNameStu.Text = "";
                return;
            }

            if (IsEmail(txtEmailStu.Text) != true)
            {
                MessageBox.Show("Must be @gmail.com, ex: abc123@gmail.com.", "Thông báo");
                txtEmailStu.Text = "";
                return;
            }


            if (txtNameStu.Text.Length >= 50)
            {
                MessageBox.Show(this, "Tên không vượt quá 50 kí tự.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (txtPhoneStu.Text.Length == 10)
            {
                if (IsNumber(txtPhoneStu.Text) != true)
                {
                    MessageBox.Show("Dữ liệu nhập không hợp lệ,sđt chỉ chứa số.", "Thông báo");
                    txtPhoneStu.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "Phone number không hợp lệ.Chỉ tồn tại 10 số.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int c = 0;
                foreach (var i in stu.tblStudents)
                {
                    foreach (var j in stu.tblSubjects)
                    {
                        if (j.deptName == cBDeptNameSub.Text)
                        {
                            c = j.deptId;
                        }

                        if (i.stuName == txtNameStu.Text && i.deptId == Convert.ToInt16(c))
                        {
                            MessageBox.Show(this, "Đã đăng kí môn này.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                tblStudent student = new tblStudent();
                student.stuName = txtNameStu.Text;  
                student.stuEmail = txtEmailStu.Text;
                student.stuPhone = txtPhoneStu.Text;
                student.stuPass = txtPhoneStu.Text;
                student.stuGender = checkBox1.Checked ? true : false;
                student.deptId = Convert.ToInt32(cBDeptNameSub.Text);

                stu.tblStudents.Add(student);
                await stu.SaveChangesAsync();
                await LoadData2(stu);
                MessageBox.Show(this, "Insert-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnResetStu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdStu.Text) && string.IsNullOrEmpty(txtNameStu.Text) && string.IsNullOrEmpty(txtEmailStu.Text) && string.IsNullOrEmpty(txtPhoneStu.Text) && string.IsNullOrEmpty(txtIdSub.Text) && string.IsNullOrEmpty(cBDeptNameSub.Text))
            {
                MessageBox.Show(this, "Đã làm trống các ô.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    txtIdStu.Text = "";
                    txtNameStu.Text = "";
                    txtEmailStu.Text = "";
                    txtPhoneStu.Text = "";
                    txtIdSub.Text = "";
                    cBDeptNameSub.Text = "";
                }
                catch (Exception ev)
                {

                }
                finally
                {
                    txtIdStu.DataBindings.Clear();
                    txtPhoneStu.DataBindings.Clear();
                    txtNameStu.DataBindings.Clear();
                    txtEmailStu.DataBindings.Clear();
                    txtIdSub.DataBindings.Clear();
                    cBDeptNameSub.DataBindings.Clear();
                }
            }
        }

        private async void btnDeleteStu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdStu.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống trường Id.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt16(txtIdStu.Text);

                foreach (var i in stu.tblStudents)
                {
                    foreach (var j in stu.tblExams)
                    {
                        if (Convert.ToInt16(txtIdStu.Text) == i.stuId && i.deptId != j.stuId)
                        {
                            stu.tblStudents.Remove(i);
                        }

                        if (i.stuId == j.stuId)
                        {
                            MessageBox.Show(this, "Không được xóa.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                await stu.SaveChangesAsync();
                await LoadData2(stu);
                MessageBox.Show(this, "Delete-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cbDeptStuId_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblStudents)
                {
                    if (i.stuId == Convert.ToInt16(txtIdStu.Text))
                    {
                        txtNameStu.Text = i.stuName;
                        txtEmailStu.Text = i.stuEmail;
                        txtPhoneStu.Text = i.stuPhone;
                        cBDeptNameSub.Text = i.deptId.ToString();
                        checkBox1.Checked = Convert.ToBoolean(i.stuGender);
                        MessageBox.Show(this, "Đã vào đây", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                await stu.SaveChangesAsync();
                await LoadData2(stu);
            }
        }

        private async void btnUpdateStu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameStu.Text) || string.IsNullOrEmpty(txtEmailStu.Text) || string.IsNullOrEmpty(txtPhoneStu.Text) || string.IsNullOrEmpty(cBDeptNameSub.Text))
            {
                MessageBox.Show(this, "Cần điền đẩy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt16(txtIdStu.Text);

                var stud = await stu.tblStudents.FirstOrDefaultAsync(st => st.stuId == id);

                if (stud != null)
                {
                    stud.stuEmail = txtEmailStu.Text;
                    stud.stuPhone = txtPhoneStu.Text;
                    stud.stuPass = txtPhoneStu.Text;
                    stud.stuName = txtNameStu.Text;
                    stud.stuGender = checkBox1.Checked ? true : false;

                    foreach (var j in stu.tblSubjects)
                    {
                        if (Convert.ToInt16(cBDeptNameSub.Text) == j.deptId)
                        {
                            stud.deptId = j.deptId;
                        }
                    }
                }
                await stu.SaveChangesAsync();
                await LoadData2(stu);
                MessageBox.Show(this, "Update-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnInsertExam_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNameExam.Text) || string.IsNullOrEmpty(txtMarkExam.Text) || cbStuIdExam.SelectedIndex == -1 || cbCouIdExam.SelectedIndex == -1 || string.IsNullOrEmpty(dateChooser.Text))
            {
                MessageBox.Show(this, "Cần điền đẩy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsName(txtNameExam.Text) != true)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ,tên không được nhập số và không có dấu.", "Thông báo");
                txtNameExam.Text = "";
                return;
            }

            if (IsNumber(txtMarkExam.Text) != true)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ,điểm không được nhập ký tự", "Thông báo");
                txtMarkExam.Text = "";
                return;
            }

            if (Convert.ToInt16(txtMarkExam.Text) >10)
            {
                MessageBox.Show("Điểm lớn nhất là 10.", "Thông báo");
                txtMarkExam.Text = "";
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {

                tblExam exam = new tblExam();

                exam.examName = txtNameExam.Text;
                exam.examMark = txtMarkExam.Text;
                exam.examDate = dateChooser.Text;
                exam.stuId = Convert.ToInt16(cbStuIdExam.Text);
                exam.couId = Convert.ToInt16(cbCouIdExam.Text);
                stu.tblExams.Add(exam);

                await stu.SaveChangesAsync();
                await LoadData3(stu);
                MessageBox.Show(this, "Insert-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDeleteExam_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt16(txtIdExam.Text);

                foreach (var i in stu.tblExams)
                {
                    if (i.examId == id)
                    {
                        stu.tblExams.Remove(i);
                    }
                }

                await stu.SaveChangesAsync();
                await LoadData3(stu);
                MessageBox.Show(this, "Delete-Successfully.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnInsertCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseName.Text) || string.IsNullOrEmpty(txtCourseSemester.Text))
            {
                MessageBox.Show(this, "Cần điền đẩy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsName(txtCourseName.Text) != true)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ,tên không được nhập ký tự.", "Thông báo");
                txtCourseName.Text = "";
                return;
            }

            if (IsNumber(txtCourseSemester.Text) != true)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ,khóa học không được nhập ký tự.", "Thông báo");
                txtCourseSemester.Text = "";
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblCourses)
                {
                    if (i.couName == txtCourseName.Text && i.couSemester == Convert.ToInt16(txtCourseSemester.Text))
                    {
                        MessageBox.Show(this, "Đã có khóa học này.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                tblCourse course = new tblCourse();
                course.couName = txtCourseName.Text;
                course.couSemester = Convert.ToInt16(txtCourseSemester.Text);

                stu.tblCourses.Add(course);
                await stu.SaveChangesAsync();
                await LoadData4(stu);
                MessageBox.Show(this, "Insert-Successfully.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnResetCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseName.Text) && string.IsNullOrEmpty(txtCourseSemester.Text) && string.IsNullOrEmpty(txtIdCourse.Text))
            {
                MessageBox.Show(this, "Đã làm trống các ô.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    txtCourseName.Text = "";
                    txtCourseSemester.Text = "";
                    txtIdCourse.Text = "";
                }
                catch (Exception ev)
                {

                }
                finally
                {
                    txtCourseName.DataBindings.Clear();
                    txtCourseSemester.DataBindings.Clear();
                    txtIdCourse.DataBindings.Clear();
                }
            }
        }

        private async void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCourse.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống trường Id.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt16(txtIdCourse.Text);

                foreach (var i in stu.tblExams)
                {
                    foreach (var j in stu.tblCourses)
                    {
                        if (id == j.couId && j.couId == i.couId)
                        {
                            MessageBox.Show(this, "Không xóa được.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (id == j.couId && j.couId != i.couId)
                        {
                            stu.tblCourses.Remove(j);
                        }
                    }
                }

                await stu.SaveChangesAsync();
                await LoadData4(stu);
                MessageBox.Show(this, "Delete-Successfully.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCourse.Text) || string.IsNullOrEmpty(txtCourseName.Text) || string.IsNullOrEmpty(txtCourseSemester.Text))
            {
                MessageBox.Show(this, "Cần điền đầy đủ các trường.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt16(txtIdCourse.Text);

                tblCourse course = await stu.tblCourses.FirstOrDefaultAsync(co => co.couId == id);

                if (course != null)
                {
                    course.couName = txtCourseName.Text;
                    course.couSemester = Convert.ToInt16(txtCourseSemester.Text);
                }
                await stu.SaveChangesAsync();
                await LoadData4(stu);
                MessageBox.Show(this, "Update-Successfully.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cbCourseId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void cbIdExam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnUpdateExam_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                int id = Convert.ToInt16(txtIdExam.Text);

                tblExam exam = await stu.tblExams.FirstOrDefaultAsync(ex => ex.examId == id);

                if (exam != null)
                {
                    exam.examName = txtNameExam.Text;
                    exam.examMark = txtMarkExam.Text.ToString();
                    exam.examDate = dateChooser.Text;
                    exam.stuId = Convert.ToInt16(cbStuIdExam.Text);
                    exam.couId = Convert.ToInt16(cbCouIdExam.Text);
                }
                await stu.SaveChangesAsync();
                await LoadData3(stu);
                MessageBox.Show(this, "Update-Successfully.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cbIdExam_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtIdExam.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameExam.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMarkExam.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateChooser.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbStuIdExam.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbCouIdExam.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
                {
                    foreach (var i in stu.tblStudents)
                    {
                        if (i.stuId == Convert.ToInt16(cbStuIdExam.Text))
                        {
                            txtNameStuExam.Text = i.stuName;
                        }
                    }

                    foreach (var i in stu.tblCourses)
                    {
                        if (i.couId == Convert.ToInt16(cbCouIdExam.Text))
                        {
                            txtNameCourseExam.Text = i.couName;
                        }
                    }
                }
            }
        }

        private void cbStuIdExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblStudents)
                {
                    if (i.stuId == Convert.ToInt16(cbStuIdExam.Text))
                    {
                        txtNameStuExam.Text = i.stuName;
                    }
                }
            }
        }

        private void cbCouIdExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblCourses)
                {
                    if (i.couId == Convert.ToInt16(cbCouIdExam.Text))
                    {
                        txtNameCourseExam.Text = i.couName;
                    }
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtIdCourse.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCourseName.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCourseSemester.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtIdStu.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameStu.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPhoneStu.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmailStu.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                checkBox1.Checked = Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
                cBDeptNameSub.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtIdSub.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDeptNameSubject.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCredits.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                if (string.IsNullOrEmpty(txtSearchSubject.Text))
                {
                    bindingSource1.DataSource = await stu.tblSubjects.Select(
                                s => new
                                {
                                    s.deptId,
                                    s.deptName,
                                    s.deptCredits
                                }
                                ).ToListAsync();
                    dataGridView1.DataSource = bindingSource1;
                    bindingNavigator1.BindingSource = bindingSource1;
                    return;
                }

                foreach (var i in stu.tblSubjects)
                {
                    str += i.deptName;
                }

                bool contain = str.Contains(txtSearchSubject.Text);

                if (contain == true)
                {
                    bindingSource1.DataSource = await stu.tblSubjects.Where(st => st.deptName == txtSearchSubject.Text).Select(
                        s => new
                        {
                            s.deptId,
                            s.deptName,
                            s.deptCredits
                        }
                        ).ToListAsync();
                    dataGridView1.DataSource = bindingSource1;
                    bindingNavigator1.BindingSource = bindingSource1;
                }

                txtSearchSubject.DataBindings.Clear();

            }
        }

        private async void btnSeachStudents_Click(object sender, EventArgs e)
        {


            string str = "";
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                if (string.IsNullOrEmpty(txtSearchStudents.Text))
                {
                    bindingSource2.DataSource = await stu.tblStudents.Select(
                                s => new
                                {
                                    s.stuId,
                                    s.stuName,
                                    s.stuPhone,
                                    s.stuEmail,
                                    s.stuGender,
                                    s.deptId
                                }
                                ).ToListAsync();
                    dataGridView2.DataSource = bindingSource2;
                    bindingNavigator2.BindingSource = bindingSource2;
                    return;
                }

                foreach (var i in stu.tblStudents)
                {
                    str += i.stuName;
                }

                bool contain = str.Contains(txtSearchStudents.Text);

                if (contain == true)
                {
                    bindingSource2.DataSource = await stu.tblStudents.Where(st => st.stuName == txtSearchStudents.Text).Select(
                        s => new
                        {
                            s.stuId,
                            s.stuName,
                            s.stuEmail,
                            s.stuPhone,
                            s.deptId,
                        }
                        ).ToListAsync();
                    dataGridView2.DataSource = bindingSource2;
                    bindingNavigator2.BindingSource = bindingSource2;
                }
            }
            //finally
            //{
            //    txtSearchStudents.DataBindings.Clear();
            //    dataGridView2.DataBindings.Clear();
            //    bindingSource2.Clear();
            //    bindingNavigator2.DataBindings.Clear();
            //}
        }

        private async void btnSearchExam_Click(object sender, EventArgs e)
        {
            string str = "";
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                if (string.IsNullOrEmpty(txtSearchExam.Text))
                {
                    bindingSource3.DataSource = await stu.tblExams.Select(
                                s => new
                                {
                                    s.examId,
                                    s.examName,
                                    s.examMark,
                                    s.examDate,
                                    s.stuId,
                                    s.couId
                                }
                                ).ToListAsync();
                    dataGridView3.DataSource = bindingSource3;
                    bindingNavigator3.BindingSource = bindingSource3;
                    return;
                }

                foreach (var i in stu.tblExams)
                {
                    str += i.examName;
                }

                bool contain = str.Contains(txtSearchExam.Text);

                if (contain == true)
                {
                    bindingSource3.DataSource = await stu.tblExams.Where(st => st.examName == txtSearchExam.Text).Select(
                        s => new
                        {
                            s.examId,
                            s.examName,
                            s.examMark,
                            s.examDate,
                            s.stuId,
                            s.couId
                        }
                        ).ToListAsync();
                    dataGridView3.DataSource = bindingSource3;
                    bindingNavigator3.BindingSource = bindingSource3;
                }
            }
        }

        private void txtSearchCourse_TextChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (tblCourse i in stu.tblCourses)
                {
                    (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"{i.couName} like '%{txtSearchCourse.Text}%'";
                }
            }
        }

        private async void FilterId_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource1.DataSource = await stu.tblSubjects.OrderBy(st => st.deptId).Select(s => new
                {
                    s.deptId, s.deptName, s.deptCredits
                }).ToListAsync();

                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource1.DataSource = await stu.tblSubjects.OrderByDescending(st => st.deptId).Select(s=>new
                {
                    s.deptId, s.deptName, s.deptCredits
                }).ToListAsync();

                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource1.DataSource = await stu.tblSubjects.OrderBy(st => st.deptName).Select(s => new
                {
                    s.deptId,
                    s.deptName,
                    s.deptCredits
                }).ToListAsync();

                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource2.DataSource = await stu.tblStudents.OrderBy(st => st.stuName).Select(s => new
                {
                    s.stuId,
                    s.stuName,
                    s.stuPhone,
                    s.stuEmail,
                    s.stuGender,
                    s.deptId
                }).ToListAsync();

                dataGridView2.DataSource = bindingSource2;
                bindingNavigator2.BindingSource = bindingSource2;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource2.DataSource = await stu.tblStudents.OrderByDescending(st => st.stuId).Select(s => new
                {
                    s.stuId,
                    s.stuName,
                    s.stuPhone,
                    s.stuEmail,
                    s.stuGender,
                    s.deptId

                }).ToListAsync();

                dataGridView2.DataSource = bindingSource2;
                bindingNavigator2.BindingSource = bindingSource2;
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource2.DataSource = await stu.tblStudents.OrderBy(st => st.stuPhone).Select(s => new
                {
                    s.stuId,
                    s.stuName,
                    s.stuPhone,
                    s.stuEmail,
                    s.stuGender,
                    s.deptId
                }).ToListAsync();

                dataGridView2.DataSource = bindingSource2;
                bindingNavigator2.BindingSource = bindingSource2;
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource2.DataSource = await stu.tblStudents.OrderBy(st => st.stuEmail).Select(s => new
                {
                    s.stuId,
                    s.stuName,
                    s.stuPhone,
                    s.stuEmail,
                    s.stuGender,
                    s.deptId
                }).ToListAsync();

                dataGridView2.DataSource = bindingSource2;
                bindingNavigator2.BindingSource = bindingSource2;
            }
        }

        private async void btnSearchCourse_Click(object sender, EventArgs e)
        {
            string str = "";
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                if (string.IsNullOrEmpty(txtSearchExam.Text))
                {
                    bindingSource4.DataSource = await stu.tblCourses.Select(
                                s => new
                                {
                                    s.couId,
                                    s.couName,
                                    s.couSemester
                                }
                                ).ToListAsync();
                    dataGridView4.DataSource = bindingSource4;
                    bindingNavigator4.BindingSource = bindingSource4;
                    return;
                }

                foreach (var i in stu.tblCourses)
                {
                    str += i.couName;
                }

                bool contain = str.Contains(txtSearchCourse.Text);

                if (contain == true)
                {
                    bindingSource4.DataSource = await stu.tblCourses.Where(st => st.couName == txtSearchCourse.Text).Select(
                        s => new
                        {
                            s.couId,
                            s.couName,
                            s.couSemester
                        }
                        ).ToListAsync();
                    dataGridView4.DataSource = bindingSource4;
                    bindingNavigator4.BindingSource = bindingSource4;
                }
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource3.DataSource = await stu.tblExams.OrderByDescending(st => st.examId).Select(s => new
                {
                    s.examId,
                    s.examName,
                    s.examMark,
                    s.examDate,
                    s.stuId,
                    s.couId
                }).ToListAsync();

                dataGridView3.DataSource = bindingSource3;
                bindingNavigator3.BindingSource = bindingSource3;
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource3.DataSource = await stu.tblExams.OrderByDescending(st => st.examName).Select(s => new
                {
                    s.examId,
                    s.examName,
                    s.examMark,
                    s.examDate,
                    s.stuId,
                    s.couId
                }).ToListAsync();

                dataGridView3.DataSource = bindingSource3;
                bindingNavigator3.BindingSource = bindingSource3;
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource3.DataSource = await stu.tblExams.OrderByDescending(st => st.examMark).Select(s => new
                {
                    s.examId,
                    s.examName,
                    s.examMark,
                    s.examDate,
                    s.stuId,
                    s.couId
                }).ToListAsync();

                dataGridView3.DataSource = bindingSource3;
                bindingNavigator3.BindingSource = bindingSource3;
            }
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string str = "";
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblExams)
                {
                    str += i.examDate;
                }

                bool contain = str.Contains(dateTimePicker1.Text);

                if (contain == true)
                {
                    bindingSource3.DataSource = await stu.tblExams.Where(st => st.examDate == dateTimePicker1.Text).Select(
                        s => new
                        {
                            s.examId,
                            s.examName,
                            s.examMark,
                            s.examDate,
                            s.stuId,
                            s.couId
                        }
                        ).ToListAsync();
                    dataGridView3.DataSource = bindingSource3;
                    bindingNavigator3.BindingSource = bindingSource3;
                }
                else
                {
                    MessageBox.Show(this,"Không có dữ liệu.","Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource4.DataSource = await stu.tblCourses.OrderByDescending(st => st.couId).Select(s => new
                {
                    s.couId,
                    s.couName,
                    s.couSemester
                }).ToListAsync();

                dataGridView4.DataSource = bindingSource4;
                bindingNavigator4.BindingSource = bindingSource4;
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                bindingSource4.DataSource = await stu.tblCourses.OrderByDescending(st => st.couName).Select(s => new
                {
                    s.couId,
                    s.couName,
                    s.couSemester
                }).ToListAsync();

                dataGridView4.DataSource = bindingSource4;
                bindingNavigator4.BindingSource = bindingSource4;
            }
        }

        private async void cBDeptNameSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblSubjects)
                {
                    if (Convert.ToInt16(cBDeptNameSub.Text) == i.deptId)
                    {
                        txtNameSubject.Text = i.deptName;
                    }
                }
            }
        }

        private void btnResetExam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdExam.Text) && string.IsNullOrEmpty(txtNameExam.Text) && string.IsNullOrEmpty(txtMarkExam.Text) && string.IsNullOrEmpty(cbStuIdExam.Text) && string.IsNullOrEmpty(cbCouIdExam.Text) && string.IsNullOrEmpty(txtNameStuExam.Text) && string.IsNullOrEmpty(txtNameCourseExam.Text))
            {
                MessageBox.Show(this, "Đã làm trống các ô.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    txtIdExam.Text = "";
                    txtNameExam.Text = "";
                    txtMarkExam.Text = "";
                    cbStuIdExam.Text = "";
                    cbCouIdExam.Text = "";
                    txtNameStuExam.Text = "";
                    txtNameCourseExam.Text = "";
                }
                catch (Exception ev)
                {

                }
                finally
                {
                    txtIdExam.DataBindings.Clear();
                    txtNameExam.DataBindings.Clear();
                    txtMarkExam.DataBindings.Clear();
                    cbStuIdExam.DataBindings.Clear();
                    cbCouIdExam.DataBindings.Clear();
                    txtNameStuExam.DataBindings.Clear();
                    txtNameCourseExam.DataBindings.Clear();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private async void cBDeptNameSub_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblSubjects)
                {
                    cBDeptNameSub.Items.Add(i.deptId);
                }
                cBDeptNameSub.Items.Clear();
            }
        }

        private async void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private async void tabControl1_Click(object sender, EventArgs e)
        {
            cBDeptNameSub.Items.Clear();
            cbStuIdExam.Items.Clear();
            cbCouIdExam.Items.Clear();
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                await LoadData2(stu);

                await LoadData3(stu);

                await LoadData4(stu);

                foreach (var i in stu.tblSubjects)
                {
                    cBDeptNameSub.Items.Add(i.deptId);
                }
                foreach (var i in stu.tblStudents)
                {
                    cbStuIdExam.Items.Add(i.stuId);
                }
                foreach (var i in stu.tblCourses)
                {
                    cbCouIdExam.Items.Add(i.couId);
                }
            }
        }

        private async void btnLoaddingSubject_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                await LoadData(stu);
            }
        }

        private async void btnLoaddingStudents_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                await LoadData2(stu);
            }
        }

        private async void btnLoaddingExam_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                await LoadData3(stu);
            }
        }

        private async void btnLoaddingCourse_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                await LoadData4(stu);
            }
        }

        private void cbStuIdExam_Click(object sender, EventArgs e)
        {

        }

        private void cbCouIdExam_Click(object sender, EventArgs e)
        {

        }

        private void cBDeptNameSub_Click_1(object sender, EventArgs e)
        {
            cBDeptNameSub.Items.Clear();
            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                foreach (var i in stu.tblSubjects)
                {
                    cBDeptNameSub.Items.Add(i.deptId);
                }
            }
        }
    }
}
