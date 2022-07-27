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
    public partial class Form2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into client_login values (@firstname,@lastname,@email,@age,@address,@phone,@user,@pass)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@age", textBox5.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@phone", textBox6.Text);
                cmd.Parameters.AddWithValue("@user", textBox7.Text);
                cmd.Parameters.AddWithValue("@pass", textBox8.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Registred", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 f = new Form1();
                    f.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("PLease fill the form", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            resetcontrol();

        }

         void resetcontrol()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }

        private void button2_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter your First name please");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider2.SetError(this.textBox6, "Enter your phone number please");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider3.SetError(this.textBox7, "Enter your Username please");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text) == true)
            {
                textBox8.Focus();
                errorProvider4.SetError(this.textBox8, "Enter your password please");
            }
            else
            {
                errorProvider4.Clear();
            }
        }
    }
}
