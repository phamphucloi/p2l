using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp12.Model;

namespace WindowsFormsApp12
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            using (PHAMPHUCLOIEntities1 stu = new PHAMPHUCLOIEntities1())
            {
                try
                {
                    foreach (var i in stu.tblStudents)
                    {
                        if (i.stuEmail == txtAcc.Text && i.stuPass == txtPass.Text)
                        {
                            Form1 f1 = new Form1();
                            f1.Show();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu sai.");
                            return;
                        }
                    }
                }
                catch (Exception ev)
                {
                    MessageBox.Show(ev.Message);
                }
                finally
                {
                    f2.Visible = false;
                }
            }
        }
    }
}
