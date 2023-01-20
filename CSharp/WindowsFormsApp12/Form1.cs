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

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                await LoadData(stu);

                await LoadData2(stu);

                foreach (var i in stu.tblStudents)
                {
                    cbDeptStuId.Items.Add(i.stuId);
                    cbStuIdExam.Items.Add(i.stuId);
                }

                await LoadData3(stu);

                await LoadData4(stu);

                foreach (var i in stu.tblCourses)
                {
                    cbCourseId.Items.Add(i.couId);
                    cbCouIdExam.Items.Add(i.couId);
                }

                foreach (var i in stu.tblExams)
                {
                    cbIdExam.Items.Add(i.examId);
                }
            }
        }

        private async Task LoadData4(PHAMPHUCLOIEntities stu)
        {
            bindingSource4.DataSource = await stu.tblCourses.Select(co => new
            {
                co.couId,
                co.couName,
                co.couSemester
            }).ToListAsync();
            dataGridView4.DataSource = bindingSource4;
            bindingNavigator4.BindingSource = bindingSource4;
        }

        private async Task LoadData3(PHAMPHUCLOIEntities stu)
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
        }

        private async Task LoadData2(PHAMPHUCLOIEntities stu)
        {
            bindingSource2.DataSource = await stu.tblStudents.Select(st => new
            {
                st.stuId,
                st.stuName,
                st.stuPhone,
                st.stuEmail,
                st.deptId
            }).ToListAsync();
            dataGridView2.DataSource = bindingSource2;
            bindingNavigator2.BindingSource = bindingSource2;
        }

        private async Task LoadData(PHAMPHUCLOIEntities stu)
        {

            foreach (var i in stu.tblSubjects)
            {
                cbDeptId.Items.Add(i.deptId);
                cBDeptNameSub.Items.Add(i.deptName);

            }

            bindingSource1.DataSource = await stu.tblSubjects.Select(st => new
            {
                st.deptId,
                st.deptName,
                st.deptCredits
            }).ToListAsync();

            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeptNameSubject.Text) || string.IsNullOrEmpty(txtCredits.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống các field.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
            try
            {
                txtDeptNameSubject.Text = "";
                txtCredits.Text = "";
                cbDeptId.Text = "";
            }
            catch (Exception ev)
            {

            }
            finally
            {
                txtDeptNameSubject.DataBindings.Clear();
                txtCredits.DataBindings.Clear();
                cbDeptId.DataBindings.Clear();
            }
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                if (string.IsNullOrEmpty(cbDeptId.Text) || string.IsNullOrEmpty(txtDeptNameSubject.Text) || string.IsNullOrEmpty(txtCredits.Text))
                {
                    MessageBox.Show(this, "Không được bỏ trống các field.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int id = Convert.ToInt16(cbDeptId.Text);

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
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt32(cbDeptId.Text);

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

            if (string.IsNullOrEmpty(cbDeptId.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống trường Id.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt32(cbDeptId.Text);

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
            if (string.IsNullOrEmpty(txtNameStu.Text) || string.IsNullOrEmpty(txtEmailStu.Text) || string.IsNullOrEmpty(txtPhoneStu.Text) || string.IsNullOrEmpty(cBDeptNameSub.Text))
            {
                MessageBox.Show(this, "Cần điền đẩy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
                            MessageBox.Show(this, "Đã đăng kí môn " + j.deptName + ".", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                tblStudent student = new tblStudent();
                student.stuName = txtNameStu.Text;
                student.stuEmail = txtEmailStu.Text;
                student.stuPhone = txtPhoneStu.Text;
                student.stuPass = txtPhoneStu.Text;
                foreach (var i in stu.tblSubjects)
                {
                    if (i.deptName == cBDeptNameSub.Text)
                    {
                        student.deptId = i.deptId;
                    }
                }

                stu.tblStudents.Add(student);
                await stu.SaveChangesAsync();
                await LoadData2(stu);
                MessageBox.Show(this, "Insert-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private async void btnResetStu_Click(object sender, EventArgs e)
        {
            try
            {
                txtNameStu.Text = "";
                txtEmailStu.Text = "";
                txtPhoneStu.Text = "";
                cbDeptId.Text = "";
                cBDeptNameSub.Text = "";
            }
            catch (Exception ev)
            {

            }
            finally
            {
                txtPhoneStu.DataBindings.Clear();
                txtNameStu.DataBindings.Clear();
                txtEmailStu.DataBindings.Clear();
                cbDeptId.DataBindings.Clear();
                cBDeptNameSub.DataBindings.Clear();
            }
        }

        private async void btnDeleteStu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbDeptId.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống trường Id.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(cbDeptStuId.Text);

                foreach (var i in stu.tblStudents)
                {
                    if (i.stuId == id)
                    {
                        stu.tblStudents.Remove(i);
                    }
                }
                await stu.SaveChangesAsync();
                await LoadData2(stu);
                MessageBox.Show(this, "Delete-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private async void cbDeptStuId_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                foreach (var i in stu.tblStudents)
                {
                    if (i.stuId == Convert.ToInt16(cbDeptStuId.Text))
                    {
                        txtNameStu.Text = i.stuName;
                        txtEmailStu.Text = i.stuEmail;
                        txtPhoneStu.Text = i.stuPhone;
                        cBDeptNameSub.Text = i.deptId.ToString();
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

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(cbDeptStuId.Text);

                var stud = await stu.tblStudents.FirstOrDefaultAsync(st => st.stuId == id);

                if (stud != null)
                {
                    stud.stuEmail = txtEmailStu.Text;
                    stud.stuPhone = txtPhoneStu.Text;
                    stud.stuPass = txtPhoneStu.Text;
                    stud.stuName = txtNameStu.Text;
                    foreach (var j in stu.tblSubjects)
                    {
                        if (cBDeptNameSub.Text == j.deptName)
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
            if (string.IsNullOrEmpty(txtNameExam.Text) || string.IsNullOrEmpty(txtMarkExam.Text) || string.IsNullOrEmpty(cbStuIdExam.Text) || string.IsNullOrEmpty(cbCouIdExam.Text) || string.IsNullOrEmpty(dateChooser.Text))
            {
                MessageBox.Show(this, "Cần điền đẩy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(cbIdExam.Text);

                foreach (var i in stu.tblExams)
                {
                    if (i.examId == id)
                    {
                        stu.tblExams.Remove(i);
                    }
                }

                await stu.SaveChangesAsync();
                await LoadData3(stu);
                MessageBox.Show(this, "Delete-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnInsertCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseName.Text) || string.IsNullOrEmpty(txtCourseSemester.Text))
            {
                MessageBox.Show(this, "Cần điền đẩy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                tblCourse course = new tblCourse();
                course.couName = txtCourseName.Text;
                course.couSemester = Convert.ToInt16(txtCourseSemester.Text);

                stu.tblCourses.Add(course);
                await stu.SaveChangesAsync();
                await LoadData4(stu);
                MessageBox.Show(this, "Insert-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnResetCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseName.Text) || string.IsNullOrEmpty(txtCourseSemester.Text) || string.IsNullOrEmpty(cbCourseId.Text))
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
                    cbCourseId.Text = "";
                }
                catch (Exception ev)
                {

                }
                finally
                {
                    txtCourseName.DataBindings.Clear();
                    txtCourseSemester.DataBindings.Clear();
                    cbCourseId.DataBindings.Clear();
                }
            }
        }

        private async void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCourseId.Text))
            {
                MessageBox.Show(this, "Không được bỏ trống trường Id.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(cbCourseId.Text);

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
                MessageBox.Show(this, "Delete-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCourseId.Text) || string.IsNullOrEmpty(txtCourseName.Text) || string.IsNullOrEmpty(txtCourseSemester.Text))
            {
                MessageBox.Show(this, "Cần điền đầy đủ các trường.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(cbCourseId.Text);

                tblCourse course = await stu.tblCourses.FirstOrDefaultAsync(co => co.couId == id);

                if (course != null)
                {
                    course.couName = txtCourseName.Text;
                    course.couSemester = Convert.ToInt16(txtCourseSemester.Text);
                }
                await stu.SaveChangesAsync();
                await LoadData4(stu);
                MessageBox.Show(this, "Update-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cbCourseId_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                foreach (var i in stu.tblCourses)
                {
                    if (i.couId == Convert.ToInt16(cbCourseId.Text))
                    {
                        txtCourseName.Text = i.couName;
                        txtCourseSemester.Text = i.couSemester.ToString();
                    }
                }
                await stu.SaveChangesAsync();
                await LoadData4(stu);
            }
        }

        private async void cbIdExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                foreach (var i in stu.tblExams)
                {
                    if (Convert.ToInt16(cbIdExam.Text) == i.examId)
                    {
                        txtNameExam.Text = i.examName;
                        txtMarkExam.Text = i.examMark;
                        dateChooser.Text = i.examDate;
                        cbCouIdExam.Text = i.couId.ToString();
                        cbStuIdExam.Text = i.stuId.ToString();
                    }
                }
                await stu.SaveChangesAsync();
                await LoadData4(stu);
            }
        }

        private async void btnUpdateExam_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                int id = Convert.ToInt16(cbIdExam.Text);

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
                MessageBox.Show(this, "Update-Successfully", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cbIdExam_Click(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                await LoadData3(stu);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                cbIdExam.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameExam.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMarkExam.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateChooser.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbStuIdExam.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbCouIdExam.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
                cbCourseId.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCourseName.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCourseSemester.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                cbDeptStuId.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameStu.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPhoneStu.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmailStu.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                cBDeptNameSub.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                cbDeptId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDeptNameSubject.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCredits.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
                }
            }
            catch (Exception ev)
            {

            }
            finally
            {
                txtSearchSubject.DataBindings.Clear();
                dataGridView1.DataBindings.Clear();
                bindingSource1.Clear();
                bindingNavigator1.DataBindings.Clear();
            }
        }

        private async void btnSeachStudents_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            try
            {
                string str = "";
                using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
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
                        (dataGridView2 as DataGridView).DataSource. = bindingNavigator2;
                    }
                }
            }
            catch (Exception ev)
            {

            }
            finally
            {
                txtSearchStudents.DataBindings.Clear();
                dataGridView2.DataBindings.Clear();
                bindingSource2.Clear();
                bindingNavigator2.DataBindings.Clear();
            }
        }

        private void btnSearchExam_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchExam.Text;
            int rowIndex = -1;

           dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells[row.Index].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        dataGridView3.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void txtSearchCourse_TextChanged(object sender, EventArgs e)
        {
            using (PHAMPHUCLOIEntities stu = new PHAMPHUCLOIEntities())
            {
                foreach (tblCourse i in stu.tblCourses)
                {
                    (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"{i.couName} like '%{txtSearchCourse.Text}%'";
                }
            }
        }



    }
}
