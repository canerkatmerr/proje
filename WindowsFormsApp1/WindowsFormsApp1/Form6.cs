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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void kadi_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True");

        private void Kaydet_Click(object sender, EventArgs e)
        {
          
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 y = new Form1();
            y.ShowDialog();

        }
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        private void button2_Click(object sender, EventArgs e)
        {
            string x = kadi.Text;
            string y = sifre.Text;
            con = new SqlConnection("Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM ogretmenbilgi where KullanıcıAdı='" + kadi.Text + "' AND Sifre='" + sifre.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                Form7 ygiris = new Form7();
                this.Hide();
                ygiris.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı girişi yaptınız! Lütfen bilgilerinizi  doğru girdiğinizden emin olunuz.");
            }
            con.Close();
        }

        private void sifre_TextChanged(object sender, EventArgs e)
        {
            sifre.PasswordChar = '*';
        }
    }
}
