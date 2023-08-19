using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Protein_Mağazası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string Sellername = "";
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\heromegadb.mdf;Integrated Security=True;Connect Timeout=30");

        // "Giriş Yap" düğmesine tıklandığında çalışan olay
        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Giriniz!");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1 && RoleCb.SelectedItem.ToString() == "ADMIN")
                {
                    if (UnameTb.Text == "Admin" && PassTb.Text == "Admin")
                    {
                        UrunFormu prod = new UrunFormu();
                        prod.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Eğer adminseniz Kullanıcı Adı ve Şifreyi Doğru Giriniz!");
                    }
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SatıcıTbl WHERE Satıcıİsim=@Uname AND SatıcıŞifre=@Pass", Con);
                    cmd.Parameters.AddWithValue("@Uname", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@Pass", PassTb.Text);
                    int rowCount = (int)cmd.ExecuteScalar();
                    Con.Close();

                    if (rowCount == 1)
                    {
                        Sellername = UnameTb.Text;
                        SatisFormu sell = new SatisFormu();
                        sell.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Kullanıcı Adı ve Şifre");
                    }
                }
            }
        }

        // "Temizle" etiketine tıklandığında çalışan olay
        private void label3_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PassTb.Text = "";
        }

        // "Çıkış" etiketine tıklandığında çalışan olay
        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // "Şifreyi Göster" onay kutusu değiştiğinde çalışan olay
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PassTb.PasswordChar = '\0'; // Karakterleri göster
            }
            else
            {
                PassTb.PasswordChar = '*'; // Karakterlerin yerine * koy
            }
        }
    }
}