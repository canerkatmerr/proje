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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2PED3V9\\SQLEXPRESS;Initial Catalog=canekatmerproje;Integrated Security=True");
        void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * From yoneticigiris ", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void Form10_Load(object sender, EventArgs e)
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
                    textBox3.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;

                    textBox3.Text = a.ToString();
                }
           
                listele();
            }
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string x = "INSERT INTO yoneticigiris(Id,KullanıcıAdı,Sifre) VALUES('"+textBox3.Text+"','" +textBox1.Text+"','"+textBox2.Text+ "')";
            SqlDataAdapter a = new SqlDataAdapter(x, baglanti);
            a.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            this.Hide();
            Form10 main = new Form10();
            main.Show();
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string k = "Delete From yoneticigiris where Id='" + textBox3.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(k, baglanti);
            da.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
           
            listele();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            string x0 = dataGridView1.Rows[x].Cells[0].Value.ToString();
            string x1 = dataGridView1.Rows[x].Cells[1].Value.ToString();
            string x2 = dataGridView1.Rows[x].Cells[2].Value.ToString();


            textBox3.Text = x0;
            textBox1.Text = x1;
            textBox2.Text = x2;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string query = "Update yoneticigiris Set KullanıcıAdı='" + textBox1.Text + "',Sifre='" +textBox2.Text+ "'WHERE Id='" + textBox3.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, baglanti);
            SDA.SelectCommand.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
