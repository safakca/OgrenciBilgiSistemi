using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgreciBilsiSistemi.Forms
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitFormu frm = new KayitFormu();
            this.Hide();
            frm.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ogrenci listeleme boyle bir ogrenci kayitlimi
            //kayitliysa , ogrenci no ve sifresini kontrol et
            //giris basarıli de

          

            if (KayitFormu.ogrencilistesi.Count>0)
            {
                foreach (Classes.OgrenciKayit item in KayitFormu.ogrencilistesi)
                {
                    if (item.Sifre==txtbxSire.Text)
                    {
                        MessageBox.Show("Giris basarili");
                    }
                    else if (item.Sifre!= txtbxSire.Text || item.OgreciNumarasi != item.KimlikNo)
                    {

                    }
                 
                }
            }

        }
    }
}
