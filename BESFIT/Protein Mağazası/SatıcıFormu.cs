using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protein_Mağazası
{
    public partial class SatıcıFormu : Form
    {
        public SatıcıFormu()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\heromegadb.mdf;Integrated Security=True;Connect Timeout=30");

        // Veritabanından satıcıları alıp DataGridView'e dolduran metot
        private void populate()
        {
            Con.Open();
            string sorgu = "select * from SatıcıTbl where SatıcıİD = @SatıcıİD";
            SqlCommand cmd = new SqlCommand(sorgu, Con);
            cmd.Parameters.AddWithValue("@SatıcıİD", Sid.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        // "Satıcı Ekle" butonuna tıklandığında gerçekleşen olay
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sname.Text == "" || Sid.Text == "" || Sage.Text == "" || Sphone.Text == "" || Spass.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi...");
                }
                else
                {
                    Con.Open();
                    string sorgu = "insert into SatıcıTbl values(@Sid, @Sname, @Sage, @Sphone, @Spass)";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.Parameters.AddWithValue("@Sid", Sid.Text);
                    cmd.Parameters.AddWithValue("@Sname", Sname.Text);
                    cmd.Parameters.AddWithValue("@Sage", Sage.Text);
                    cmd.Parameters.AddWithValue("@Sphone", Sphone.Text);
                    cmd.Parameters.AddWithValue("@Spass", Spass.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Satıcıyı Başarıyla Eklediniz!");
                    Con.Close();
                    populate();
                    Sid.Text = "";
                    Sname.Text = "";
                    Sphone.Text = "";
                    Spass.Text = "";
                    Sage.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Panelin Paint olayına bağlı olarak, form yüklendiğinde DataGridView'i doldurur
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            populate();
        }

        // DataGridView'de bir hücreye tıklanıldığında gerçekleşen olay
        private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Sid.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            Sname.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            Sage.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            Sphone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            Spass.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        // "Satıcı Sil" butonuna tıklandığında gerçekleşen olay
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sid.Text == "")
                {
                    MessageBox.Show("Silinecek Satıcıyı Seçiniz!");
                }
                else
                {
                    Con.Open();
                    string sorgu = "delete from SatıcıTbl where SatıcıİD=@Sid";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.Parameters.AddWithValue("@Sid", Sid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Satıcıyı Başarıyla Sildiniz!");
                    Con.Close();
                    populate();
                    Sid.Text = "";
                    Sname.Text = "";
                    Sphone.Text = "";
                    Spass.Text = "";
                    Sage.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // "Satıcı Güncelle" butonuna tıklandığında gerçekleşen olay
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sname.Text == "" || Sid.Text == "" || Sage.Text == "" || Sphone.Text == "" || Spass.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi...");
                }
                else
                {
                    Con.Open();
                    string sorgu = "update SatıcıTbl set Satıcıİsim=@Sname, SatıcıYaş=@Sage, SatıcıTel=@Sphone, SatıcıŞifre=@Spass where SatıcıİD=@Sid";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.Parameters.AddWithValue("@Sname", Sname.Text);
                    cmd.Parameters.AddWithValue("@Sage", Sage.Text);
                    cmd.Parameters.AddWithValue("@Sphone", Sphone.Text);
                    cmd.Parameters.AddWithValue("@Spass", Spass.Text);
                    cmd.Parameters.AddWithValue("@Sid", Sid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Satıcı Başarıyla Güncellendi!");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // "Ürünler" butonuna tıklandığında gerçekleşen olay
        private void button1_Click(object sender, EventArgs e)
        {
            UrunFormu urun = new UrunFormu();
            urun.Show();
            this.Hide();
        }

        // "Kategoriler" butonuna tıklandığında gerçekleşen olay
        private void button2_Click(object sender, EventArgs e)
        {
            KategoriForm kategori = new KategoriForm();
            kategori.Show();
            this.Hide();
        }

        // "Çıkış" etiketine tıklandığında gerçekleşen olay
        private void label7_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }
    }
}
//Bu kod, Protein Mağazası uygulamasının Satıcı Formu'nu temsil eder. Bu form, satıcıları yönetmek için kullanılır.
 //Satıcı eklemek, silmek ve güncellemek için işlemler gerçekleştirilir.
 //Ayrıca, ürünler ve kategoriler gibi diğer işlevlere erişim sağlar.
 //Veritabanı bağlantısı ve gerekli sorgular kullanılarak satıcılar DataGridView'e doldurulur