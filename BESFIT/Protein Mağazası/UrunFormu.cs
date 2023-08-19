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
    public partial class UrunFormu : Form
    {
        public UrunFormu()
        {
            InitializeComponent();
        }

        // Veritabanı bağlantısı için SqlConnection nesnesi tanımlanıyor
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\heromegadb.mdf;Integrated Security=True;Connect Timeout=30");

        // KategoriCombo'nun verilerini dolduran metot
        private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Katİsim FROM KategoriTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Katİsim", typeof(string));
            dt.Load(rdr);
            CatCb.ValueMember = "Katİsim";
            CatCb.DataSource = dt;
            Con.Close();
        }

        // Form yüklendiğinde çalışacak olan metot
        private void UrunFormu_Load(object sender, EventArgs e)
        {
            fillcombo(); // KategoriCombo'nun verilerini doldur
            populate(); // Ürünleri listele
        }

        // Ürünleri DataGridView'e dolduran metot
        private void populate()
        {
            Con.Open();
            string sorgu = "SELECT * FROM ÜrünTbl";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        // DataGridView'de bir hücreye tıklandığında çalışacak olan metot
        private void ProdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen ürünün verilerini ilgili TextBox ve ComboBox'lara aktar
            ProdId.Text = ProdDGV.SelectedRows[0].Cells[0].Value.ToString();
            ProdName.Text = ProdDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProdMktr.Text = ProdDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = ProdDGV.SelectedRows[0].Cells[3].Value.ToString();
            CatCb.SelectedValue = ProdDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        // Ürün ekleme butonuna tıklandığında çalışacak olan metot
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdId.Text == "" || ProdName.Text == "" || ProdMktr.Text == "" || ProdPrice.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi...");
                }
                else
                {
                    Con.Open();
                    string sorgu = "INSERT INTO ÜrünTbl (ÜrünID, Ürünİsim, ÜrünMiktar, ÜrünFiyat, ÜrünKategori) VALUES (" + ProdId.Text + ",'" + ProdName.Text + "','" + ProdMktr.Text + "'," + ProdPrice.Text + ",'" + CatCb.SelectedValue.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürünü Başarıyla Eklediniz");
                    Con.Close();
                    populate(); // Ürünleri güncelle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Kategori formunu açan butonun tıklanma olayı
        private void button2_Click(object sender, EventArgs e)
        {
            KategoriForm cat = new KategoriForm();
            cat.Show();
            this.Hide();
        }

        // Ürün güncelleme butonuna tıklandığında çalışacak olan metot
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdId.Text == "" || ProdName.Text == "" || ProdMktr.Text == "" || ProdPrice.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi...");
                }
                else
                {
                    Con.Open();
                    string sorgu = "UPDATE ÜrünTbl SET Ürünİsim=@Ürünİsim, ÜrünMiktar=@ÜrünMiktar, ÜrünFiyat=@ÜrünFiyat, ÜrünKategori=@ÜrünKategori WHERE ÜrünID=@ÜrünID";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.Parameters.AddWithValue("@Ürünİsim", ProdName.Text);
                    cmd.Parameters.AddWithValue("@ÜrünMiktar", ProdMktr.Text);
                    cmd.Parameters.AddWithValue("@ÜrünFiyat", ProdPrice.Text);
                    cmd.Parameters.AddWithValue("@ÜrünKategori", CatCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ÜrünID", ProdId.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün Başarıyla Güncellendi!");
                    Con.Close();
                    populate(); // Ürünleri güncelle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Kategori ComboBox'ının değeri değiştiğinde çalışacak olan metot
        private void SearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.Open();
            string sorgu = "SELECT * FROM ÜrünTbl WHERE ÜrünKategori = '" + CatCb.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        // Çıkış yapma butonunun tıklanma olayı
        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        // Satıcı formunu açma butonunun tıklanma olayı
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SatıcıFormu satıcı = new SatıcıFormu();
            satıcı.Show();
        }

        // Ürünleri yenileme butonunun tıklanma olayı
        private void button8_Click(object sender, EventArgs e)
        {
            populate(); // Ürünleri güncelle
        }

        // Ürünü çıkarma butonunun tıklanma olayı
        private void Çıkar_Click(object sender, EventArgs e)
        {
            if (ProdDGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili ürünü silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int selectedRowIndex = ProdDGV.SelectedRows[0].Index;
                        int productId = Convert.ToInt32(ProdDGV.Rows[selectedRowIndex].Cells["ÜrünID"].Value);

                        Con.Open();
                        string sorgu = "DELETE FROM ÜrünTbl WHERE ÜrünID = @ÜrünID";
                        SqlCommand cmd = new SqlCommand(sorgu, Con);
                        cmd.Parameters.AddWithValue("@ÜrünID", productId);
                        cmd.ExecuteNonQuery();
                        Con.Close();

                        MessageBox.Show("Ürün başarıyla silindi.");
                        populate(); // Ürünleri güncelle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin.");
            }
        }
    }
}