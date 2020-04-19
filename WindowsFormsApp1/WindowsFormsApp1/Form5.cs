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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            int a;
            string cnstr = "Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True";
            SqlConnection con = new SqlConnection(cnstr);
            con.Open();
            string query = "select Max(Cast(Id as Int)) from ogrbilgi";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    id.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;

                    id.Text = a.ToString();
                }
            }
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            listele();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True");

        DataSet ds = new DataSet();
        void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * From ogrbilgi ", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from ogrbilgi Where OkulNumarası='" + x.Text + "'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string x = "INSERT INTO ogrbilgi (Id,Adı,Soyadı,OkulNumarası,Sınıf,DogumTarihi,Adres,KullanıcıAdı,Sifre,Tutanak) VALUES('"+id.Text+"','"+ad.Text+ "','"+soyad.Text+"','"+on.Text+ "','"+snf.Text+ "','" + dt.Text+ "','" + adrs.Text + "','" +kullanıcıadı.Text+"','"+sifre.Text+"','"+tutanak.Text+"')";
            SqlDataAdapter a = new SqlDataAdapter(x, baglanti);
            a.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            Form5 main = new Form5();
            this.Hide();
            main.Show();

        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string query = "Update ogrbilgi Set Adı='" + ad.Text + "',Soyadı='" + soyad.Text + "',OkulNumarası='" + on.Text + "',Sınıf='" + snf.Text + "',DogumTarihi='" + dt.Text + "',Adres='" + adrs.Text + "',KullanıcıAdı='"+kullanıcıadı.Text+"',Sifre='"+sifre.Text+  "',Tutanak='" + tutanak.Text + "'WHERE Id='" + id.Text +"'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, baglanti);
            SDA.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ad_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }

            }


        private void soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
  
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }       
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
          
        }  
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            string x0 = dataGridView1.Rows[x].Cells[0].Value.ToString();
            string x1 = dataGridView1.Rows[x].Cells[1].Value.ToString();
            string x2 = dataGridView1.Rows[x].Cells[2].Value.ToString();
            string x3 = dataGridView1.Rows[x].Cells[3].Value.ToString();
            string x4 = dataGridView1.Rows[x].Cells[4].Value.ToString();
            string x5 = dataGridView1.Rows[x].Cells[5].Value.ToString();
            string x6 = dataGridView1.Rows[x].Cells[6].Value.ToString();
            string x7 = dataGridView1.Rows[x].Cells[7].Value.ToString();
            string x8 = dataGridView1.Rows[x].Cells[8].Value.ToString();
    
            id.Text = x0;
            ad.Text = x1;
            soyad.Text = x2;
            on.Text = x3;
            snf.Text = x4;
            adrs.Text = x5;
            kullanıcıadı.Text = x6;
            sifre.Text = x7;
            tutanak.Text = x8;
        }

        private void button4_Click(object sender, EventArgs e)
        {
             baglanti.Open();
            string k  = "Delete From ogrbilgi where Id='" +id.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(k, baglanti);
            da.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            id.Clear();
            ad.Clear();
            soyad.Clear();
            on.Clear();
            adrs.Clear();
            kullanıcıadı.Clear();
            sifre.Clear();
            tutanak.Clear();

            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 k = new Form3();
            k.ShowDialog();
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }





        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıadı_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void x_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }



