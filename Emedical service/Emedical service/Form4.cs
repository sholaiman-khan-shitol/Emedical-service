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
    public partial class Form4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Visible = false;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox3.Focus();
                errorProvider1.SetError(this.textBox2, "Enter your Adress please");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider2.SetError(this.textBox3, "Enter your password please");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Enter your password please");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into client_login values (@name,@age,@address,@street,@house,@phone)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@age", textBox5.Text);
                cmd.Parameters.AddWithValue("@address", textBox2.Text);
                cmd.Parameters.AddWithValue("@street", textBox3.Text);
                cmd.Parameters.AddWithValue("@house", textBox6.Text);
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }
    }
}
