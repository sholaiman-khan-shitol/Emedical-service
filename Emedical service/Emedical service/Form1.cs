using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Emedical_service
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Visible = false;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text)==true)
            {
                textBox3.Focus();
                errorProvider1.SetError(this.textBox3, "Enter your Username please");
            }
            else 
            {
                errorProvider1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox1, "Enter your password please");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text!="" && textBox1.Text!="")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from LONGIN_DETAILES where username=@user and pass=@pass";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@user", textBox3.Text);
                cmd.Parameters.AddWithValue("@pass", textBox1.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows==true)
                {
                    MessageBox.Show("Lonin Successfull", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form3 f = new Form3();
                    f.Show();
                    this.Visible = false;
                }
                else 
                {
                    MessageBox.Show("Lonin failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("PLease fill the form", "information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch(status)
            {
                case true:
                    textBox1.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox1.UseSystemPasswordChar = true;
                    break;

                    
            }
        }
    }
}
