using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Protein_Mağazası
{
    public partial class KategoriForm : Form
    {
        public KategoriForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\heromegadb.mdf;Integrated Security=True;Connect Timeout=30");

        // "Ekle" butonuna tıklandığında çalışan olay
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIdTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi...");
                }
                else
                {
                    Con.Open();
                    string sorgu = "INSERT INTO KategoriTbl (KategoriID, Katİsim, KatÇeşit) VALUES (" + CatIdTb.Text + ",'" + CatNameTb.Text + "','" + CatDescTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategoriye Başarıyla Eklediniz");
                    Con.Close();
                    populate(); // Kategorileri güncellemek için populate() metodu çağrılıyor
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Kategorileri güncellemek için kullanılan metot
        private void populate()
        {
            Con.Open();
            string sorgu = "select * from KategoriTbl"; // KategoriTbl tablosundan tüm sütunları seç
            SqlDataAdapter sda = new SqlDataAdapter(sorgu, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        // Form yüklendiğinde çalışan olay
        private void KategoriForm_Load(object sender, EventArgs e)
        {
            populate(); // Kategori verilerini doldurmak için populate() metodu çağrılıyor
        }

        // Kategori DataGridView'inde hücreye tıklandığında çalışan olay
        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIdTb.Text = CatDGV.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = CatDGV.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTb.Text = CatDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        // "Sil" butonuna tıklandığında çalışan olay
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIdTb.Text == "")
                {
                    MessageBox.Show("Silinecek Kategoriyi Seçin");
                }
                else
                {
                    Con.Open();
                    string sorgu = "delete from KategoriTbl where KategoriID=" + CatIdTb.Text + "";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategoriyi Başarıyla Sildiniz!");
                    Con.Close();
                    populate(); // Kategorileri güncellemek için populate() metodu çağrılıyor
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // "Güncelle" butonuna tıklandığında çalışan olay
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIdTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi...");
                }
                else
                {
                    Con.Open();
                    string sorgu = "update KategoriTbl set Katİsim='" + CatNameTb.Text + "',KatÇeşit='" + CatDescTb.Text + "'where KategoriID=" + CatIdTb.Text + "";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori Başarıyla Güncellendi!");
                    Con.Close();
                    populate(); // Kategorileri güncellemek için populate() metodu çağrılıyor
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // "Ürün Ekle" butonuna tıklandığında çalışan olay
        private void button2_Click(object sender, EventArgs e)
        {
            UrunFormu urun = new UrunFormu();
            urun.Show();
            this.Hide();
        }

        // "Satıcı" butonuna tıklandığında çalışan olay
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SatıcıFormu satıcı = new SatıcıFormu();
            satıcı.Show();
        }

        // "Çıkış" etiketine tıklandığında çalışan olay
        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
    }
}