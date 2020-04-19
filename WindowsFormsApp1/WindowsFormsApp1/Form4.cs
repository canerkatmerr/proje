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
    public partial class Form4 : Form
    {
        public Form4()
        {
            
            InitializeComponent();
            
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string x = "INSERT INTO ogretmenbilgi (Id,Adı,Soyadı,Brans,DogumTarihi,OkuldaGoreveBasladıgıTarih,TatilGünleri,HaftalıkCalismaSaati,Maas,Adres,Sifre,KullanıcıAdı) VALUES('" + id.Text + "','" + ad.Text + "','" + sa.Text + "','" +br.Text + "','" + dt.Text + "','" + bt.Text + "','" + tg.Text + "','" + hs.Text + "','" + maas.Text + "','" + adres.Text + "','" + sifre.Text + "','" + kadi.Text + "')";
            SqlDataAdapter a = new SqlDataAdapter(x, baglanti);
            a.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            Form4 main = new Form4();
            this.Hide();
            main.Show();
        }
        void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * From ogretmenbilgi ", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void label5_Click(object sender, EventArgs e)
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
            string x9 = dataGridView1.Rows[x].Cells[9].Value.ToString();
            string x10 = dataGridView1.Rows[x].Cells[10].Value.ToString();
            string x11 = dataGridView1.Rows[x].Cells[11].Value.ToString();

            id.Text = x0;
            ad.Text = x1;
            sa.Text = x2;
            br.Text = x3;
            dt.Text = x4;
            bt.Text = x5;
            tg.Text = x6;
            hs.Text = x7;
            maas.Text = x8;
            kadi.Text = x9;
            sifre.Text = x10;
            adres.Text = x11;
        }

        private void maas_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int a;
            string cnstr = "Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True";
            SqlConnection con = new SqlConnection(cnstr);
            con.Open();
            string query = "select Max(Cast(Id as Int)) from ogretmenbilgi";
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

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string query = "Update ogretmenbilgi Set Adı='" + ad.Text + "',Soyadı='" + sa.Text + "',Brans='" + br.Text + "',DogumTarihi='" + dt.Text + "',OkuldaGoreveBasladıgıTarih='"+bt.Text + "',TatilGünleri='" + tg.Text + "',HaftalıkCalismaSaati='" + hs.Text + "',Adres='" + adres.Text + "',Sifre='" + sifre.Text + "',KullanıcıAdı='" + kadi.Text + "'WHERE Id='" + id.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, baglanti);
            SDA.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string k = "Delete From ogretmenbilgi where Id='" + id.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(k, baglanti);
            da.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            ad.Clear();
            sa.Clear();
            kadi.Clear();
            sifre.Clear();
            maas.Clear();

            listele();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 l = new Form3();
            l.ShowDialog();
           
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ad_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }

        }

        private void sa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }

        }

        private void br_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void br_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void hs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void maas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tg_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void hs_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from ogrbilgi Where OkulNumarası='" + x.Text + "'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
