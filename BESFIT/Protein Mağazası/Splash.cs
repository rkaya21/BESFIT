using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protein_Mağazası
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        int startpoint = 0;

        // Timer nesnesi tarafından tetiklenen olay her saniye başına gerçekleşir
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            ilerleme.Value = startpoint;

            // İlerleme çubuğunun değeri 100 olduğunda splash ekranını gizle ve giriş ekranını göster
            if (ilerleme.Value == 100)
            {
                ilerleme.Value = 0;
                timer1.Stop();
                Form1 log = new Form1();
                this.Hide();
                log.Show();
            }
        }

        // Splash formu yüklendiğinde timer'ı başlat
        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
} 
//Bu kod, Protein Mağazası uygulamasının başlangıç ekranını temsil eden bir Windows Form uygulamasını içerir.
//Ekranın alt kısmında ilerleme çubuğu bulunur. Timer nesnesi, her saniye başına gerçekleşen bir olayı tetikler ve
//ilerleme çubuğunu günceller. İlerleme çubuğunun değeri 100 olduğunda splash ekranını gizler ve giriş ekranını gösterir (Form1).