using System.Data.SqlClient;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    string sqlCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=JAVA_GROCERY_STORE;Integrated Security=True";

    //SqlConnection con = null;
    
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult a = MessageBox.Show("h1","Phạm Phúc Lợi", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

        if (a == DialogResult.OK)
        {
            MessageBox.Show("Lợi","Thông báo");
        }
        else
        {
            MessageBox.Show("Cút", "Thông báo");
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }
}
