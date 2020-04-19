using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            sifre.PasswordChar = '*';
        }
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            string x = kadi.Text;
            string y = sifre.Text;
            con = new SqlConnection("Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM yoneticigiris where KullanıcıAdı='"+kadi.Text + "' AND Sifre='" + sifre.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                Form3 ygiris = new Form3();
                this.Hide();
                ygiris.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız! Lütfen bilgilerinizi  doğru girdiğinizden emin olunuz.");
            }
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Geri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 k = new Form1();
            k.ShowDialog();

        }
    }
}
