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
    public partial class Form5 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form5()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider1.SetError(this.textBox5, "Enter your Adress please");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider2.SetError(this.textBox3, "Enter your Adress please");
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
                errorProvider3.SetError(this.textBox7, "Enter your Adress please");
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
                errorProvider4.SetError(this.textBox8, "Enter your Adress please");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider5.SetError(this.textBox4, "Enter your Adress please");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into client_login values (@name,@age,@address,@street,@house,@phone,@med,@quantity)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@age", textBox5.Text);
                cmd.Parameters.AddWithValue("@address", textBox2.Text);
                cmd.Parameters.AddWithValue("@street", textBox3.Text);
                cmd.Parameters.AddWithValue("@house", textBox6.Text);
                cmd.Parameters.AddWithValue("@med", textBox7.Text);
                cmd.Parameters.AddWithValue("@quantity", textBox8.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Confirm", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button3_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }
    }
}
