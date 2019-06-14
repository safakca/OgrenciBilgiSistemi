using OgreciBilsiSistemi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OgreciBilsiSistemi
{
    public partial class KayitFormu : Form
    {
        public KayitFormu()
        {
            InitializeComponent();
        }

        List<Bolum> bolumlistem = new List<Bolum>();

        List<Fakulte> fakultelistem = new List<Fakulte>();
        private void KayitFormu_Load(object sender, EventArgs e)
        {
            //fakulte ve bolum listesi tanımla
            fakultelistem.Add(new Fakulte { FakulteAdi = "Fen Edebiyat", FakulteKodu = "FEF" });
            fakultelistem.Add(new Fakulte { FakulteAdi = "Mühendislik", FakulteKodu = "MUH" });
            fakultelistem.Add(new Fakulte { FakulteAdi = "Güzel Sanatlar", FakulteKodu = "GSF" });

            //Bolum icin ekleme yaparken fakulteye baglı oldugu icin fakulte adını da ekle

            bolumlistem.Add(new Bolum { BolumAdi = "Elektrik Elektronik Mühendisliği", FakulteAdi = "Mühendislik", FakulteKodu = "MUH" });
            bolumlistem.Add(new Bolum { BolumAdi = "Bilgisayar Mühendisliği", FakulteAdi = "Mühendislik", FakulteKodu = "MUH" });
            bolumlistem.Add(new Bolum { BolumAdi = "İnşaat Mühendisliği", FakulteAdi = "Mühendislik", FakulteKodu = "MUH" });
            bolumlistem.Add(new Bolum { BolumAdi = "Makina Mühendisliği", FakulteAdi = "Mühendislik", FakulteKodu = "MUH" });
            bolumlistem.Add(new Bolum { BolumAdi = "Maden Mühendisliği", FakulteAdi = "Mühendislik", FakulteKodu = "MUH" });
            bolumlistem.Add(new Bolum { BolumAdi = "Jeoloji Mühendisliği", FakulteAdi = "Mühendislik", FakulteKodu = "MUH" });

            bolumlistem.Add(new Bolum { BolumAdi = "Edebiyat", FakulteAdi = "Fen Edebiyat", FakulteKodu = "FEF" });
            bolumlistem.Add(new Bolum { BolumAdi = "Matematik", FakulteAdi = "Fen Edebiyat", FakulteKodu = "FEF" });
            bolumlistem.Add(new Bolum { BolumAdi = "Fizik", FakulteAdi = "Fen Edebiyat", FakulteKodu = "FEF" });
            bolumlistem.Add(new Bolum { BolumAdi = "Kimya", FakulteAdi = "Fen Edebiyat", FakulteKodu = "FEF" });


            bolumlistem.Add(new Bolum { BolumAdi = "Mimarlık", FakulteAdi = "Güzel Sanatlar", FakulteKodu = "GSF" });
            bolumlistem.Add(new Bolum { BolumAdi = "İç Mimarlık", FakulteAdi = "Güzel Sanatlar", FakulteKodu = "GSF" });
            bolumlistem.Add(new Bolum { BolumAdi = "Grafik Animasyon", FakulteAdi = "Güzel Sanatlar", FakulteKodu = "GSF" });
            bolumlistem.Add(new Bolum { BolumAdi = "Resim", FakulteAdi = "Güzel Sanatlar", FakulteKodu = "GSF" });

            //combobox fakultemin icersine listedeki verileri at
            //(datasource)
            Helper.ComboBoxDoldur(cmbFakulte, fakultelistem, "FakulteAdi", "FakulteAdi");


        }

        private void cmbFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            //secilen fakultenin item ını yakalayıp buna gore bolum getir

            Fakulte secilenfakulte = (Fakulte)cmbFakulte.SelectedItem;

            List<Bolum> gelenbolumler = Helper.BolumGetir(secilenfakulte, bolumlistem);

            Helper.ComboBoxDoldur(cmbBolum, gelenbolumler, "BolumAdi", "BolumAdi");

            string ogrencino = ((Bolum)
                cmbBolum.SelectedItem).BolumAdi.Substring(0, 3) +
                ((Fakulte)cmbFakulte.SelectedItem).FakulteAdi.Substring(0, 3) +
                DateTime.Now.Year + (ogrencilistesi.Count() + 1);
            txtbxOgrenciNumarasi.Text = ogrencino;

        }
        //Kayıt işleminden sonra temizlemesi icin bir method yazılım
        public static void Temizle(Form form)
        {
            foreach (var item in form.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;

                }
                else if (item is RadioButton)
                {
                    ((RadioButton)item).Checked = false;
                }
                else if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now;
                }
            }
        }

        //kontrol methodum
        //textbox lar bos mu
        //sifreler uyusuyor mu?
        bool bosmu = true;
        public void BosMuKontrolu(Form form)
        {
            foreach (Control item in form.Controls)
            {
                if (item is TextBox)
                {
                    //textbox bos mu
                    if (item.Text == String.Empty)
                    {
                        //spesifikleştiriyor
                        MessageBox.Show(Convert.ToString(((TextBox)item).Name) + "boş");
                        bosmu = false;
                    }
                    //else if (((RadioButton)item).Checked == false)
                    //{
                    //    MessageBox.Show(((RadioButton)item).Name);
                    //}
                }
            }
            if (txtbxSifre.Text != txtbxSifreTekrar.Text)
            {
                MessageBox.Show("Sifreler uyusmamaktadır!");
                bosmu = false;
            }
        }
        

        public static List<OgrenciKayit> ogrencilistesi = new List<OgrenciKayit>();

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            bosmu = true;
            //kayit islemi icin;
            //listeyi olusturcam, classlarımdan instance alıcam
            //ve textbox ımdan okudugum degerleri class imdan 
            //turettigim nesneme atacagim
            try
            {
                OgrenciKayit ogr = new OgrenciKayit();
                ogr.Ad = txtbxOgrenciAdi.Text;
                ogr.Soyad = txtbxOgrenciSoyadi.Text;
                ogr.KimlikNo = txtbxKimlikNo.Text;
                ogr.OgreciNumarasi = txtbxOgrenciNumarasi.Text;
                ogr.DogumTarihi = dateTimePicOgrenci.Value;

                ogr.Bolum = ((Bolum)cmbBolum.SelectedItem).BolumAdi;

                ogr.Fakulte = ((Fakulte)
                    cmbFakulte.SelectedItem).FakulteAdi;
                if (radiobtnKadin.Checked)
                {
                    ogr.Cinsiyet = true;
                }
                else
                {
                    ogr.Cinsiyet = false;
                }
                ogr.Sifre = txtbxKimlikNo.Text;

                ogrencilistesi.Add(ogr);

                BosMuKontrolu(this);

                if (bosmu == true)
                {
                    MessageBox.Show("Ekleme başarılı ");
                    Temizle(this);
                }
                else return;
                  
            }
            catch (Exception )
            {

                throw ;
            }
        }

        private void cmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ogrencino = ((Bolum)
               cmbBolum.SelectedItem).BolumAdi.Substring(0, 3) +
               ((Fakulte)cmbFakulte.SelectedItem).FakulteAdi.Substring(0, 3) +
               DateTime.Now.Year + (ogrencilistesi.Count() + 1);
            txtbxOgrenciNumarasi.Text = ogrencino;
        }

        private void btnSifreGoster_MouseDown_1(object sender, MouseEventArgs e)
        {
            txtbxSifre.PasswordChar = '\0';
        }

        private void btnSifreGoster_MouseUp_1(object sender, MouseEventArgs e)
        {
            txtbxSifre.PasswordChar = '*';
        }

        private void btnSifreTekrarGoster_MouseDown(object sender, MouseEventArgs e)
        {
            txtbxSifreTekrar.PasswordChar = '\0';
        }

        private void btnSifreTekrarGoster_MouseUp(object sender, MouseEventArgs e)
        {
            txtbxSifreTekrar.PasswordChar = '*';

        }
    }
}
