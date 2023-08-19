using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Protein_Mağazası
{
    public partial class SatisFormu : Form
    {
        public SatisFormu()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\heromegadb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string sorgu = "SELECT Ürünİsim,ÜrünFiyat FROM ÜrünTbl";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populatebills()
        {
            Con.Open();
            string sorgu = "SELECT * FROM FaturaTbl";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void SatisFormu_Load(object sender, EventArgs e)
        {
            populate();
            populatebills();
            fillcombo();
            Satıcılbl.Text = Form1.Sellername;

            // Marka sütununu ORDERDGV'ye ekle
            DataGridViewTextBoxColumn markaColumn = new DataGridViewTextBoxColumn();
            markaColumn.HeaderText = "Marka";
            markaColumn.Name = "Marka";
            ORDERDGV.Columns.Add(markaColumn);
        }

        private void ProdDGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdName.Text = ProdDGV1.SelectedRows[0].Cells[0].Value.ToString();
            ProdPrice.Text = ProdDGV1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Tarihlbl.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        int Grdtotal = 0, n = 0;

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (BillID.Text == "")
            {
                MessageBox.Show("Eksik ID Verisi..");
            }
            else
            {
                try
                {
                    Con.Open();
                    string sorgu = "INSERT INTO FaturaTbl (FaturaId, Satıcıİsmi, FaturaTarihi, TotalMiktar) VALUES (" + BillID.Text + ",'" + Satıcılbl.Text + "','" + Tarihlbl.Text + "'," + Amtlbl.Text + ")";
                    SqlCommand cmd = new SqlCommand(sorgu, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Siparişi Başarıyla Eklediniz");
                    Con.Close();
                    populate();
                    populatebills();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BillsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // İçerik yok, bu olayı boş bırakabilirsiniz.
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PROTEİN MAGAZASI", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("FATURA ID:" + (BillsDGV.SelectedRows.Count > 0 ? BillsDGV.SelectedRows[0].Cells[0].Value.ToString() : ""), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 70));
            e.Graphics.DrawString("Satıcı İsmi:" + (BillsDGV.SelectedRows.Count > 0 ? BillsDGV.SelectedRows[0].Cells[1].Value.ToString() : ""), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Tarih:" + (BillsDGV.SelectedRows.Count > 0 ? BillsDGV.SelectedRows[0].Cells[2].Value.ToString() : ""), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Total Hesap:" + (BillsDGV.SelectedRows.Count > 0 ? BillsDGV.SelectedRows[0].Cells[3].Value.ToString() : ""), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 160));

            if (ORDERDGV.Rows.Count > 0)
            {
                e.Graphics.DrawString("Marka:" + ORDERDGV.Rows[0].Cells[5].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 190));
            }
            else
            {
                e.Graphics.DrawString("Marka: (Seçilmedi)", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 190));
            }

            e.Graphics.DrawString("Recep Enes KAYA, Fatih AKMAN", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.Red, new Point(270, 230));
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void SearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.Open();
            string sorgu = "SELECT Ürünİsim, ÜrünFiyat FROM ÜrünTbl WHERE ÜrünKategori = '" + SearchCb.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sorgu, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Katİsim from KategoriTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Katİsim", typeof(string));
            dt.Load(rdr);
            SearchCb.ValueMember = "Katİsim";
            SearchCb.DataSource = dt;
            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (BillsDGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = BillsDGV.SelectedRows[0];
                if (!selectedRow.IsNewRow) // Kaydedilmemiş yeni bir satır değilse
                {
                    int selectedRowIndex = selectedRow.Index;
                    int invoiceId = Convert.ToInt32(selectedRow.Cells["FaturaId"].Value); // FaturaId sütunundaki değeri al

                    // Veritabanından silme işlemini gerçekleştir
                    Con.Open();
                    string deleteQuery = "DELETE FROM FaturaTbl WHERE FaturaId = @InvoiceId";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, Con);
                    deleteCommand.Parameters.AddWithValue("@InvoiceId", invoiceId);
                    deleteCommand.ExecuteNonQuery();
                    Con.Close();

                    BillsDGV.Rows.RemoveAt(selectedRowIndex);
                }
                else
                {
                    MessageBox.Show("Kaydedilmemiş yeni satır silinemez.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir satır seçin.");
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (ProdName.Text == "" || ProdQty.Text == "")
            {
                MessageBox.Show("Lütfen diğer verileri doldurunuz...");
            }
            else
            {
                string productName = ProdDGV1.SelectedRows[0].Cells[0].Value.ToString(); // Seçili ürünün adını al
                string productPrice = ProdDGV1.SelectedRows[0].Cells[1].Value.ToString(); // Seçili ürünün fiyatını al
                string selectedMarka = SearchCb.SelectedValue.ToString(); // Seçili markayı al

                int total = Convert.ToInt32(productPrice) * Convert.ToInt32(ProdQty.Text);

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ORDERDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = productName;
                newRow.Cells[2].Value = productPrice;
                newRow.Cells[3].Value = ProdQty.Text;
                newRow.Cells[4].Value = total;
                newRow.Cells[5].Value = selectedMarka;
                ORDERDGV.Rows.Add(newRow);

                Grdtotal = Grdtotal + total;
                Amtlbl.Text = Grdtotal.ToString();

                n++;
            }
        }
    }
}