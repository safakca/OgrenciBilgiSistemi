using OgreciBilsiSistemi.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OgreciBilsiSistemi
{
    class Helper
    {

        public static void ComboBoxDoldur(ComboBox cmb, ICollection list,
            string DisplayMember, string ValueMember)
        {  //generic method
            cmb.DataSource = list;
            cmb.DisplayMember = DisplayMember;
            cmb.ValueMember = ValueMember;
        }
        public static List<Bolum> BolumGetir(Fakulte gelenfakulte, List<Bolum> bolumlistem)
        {
            List<Bolum> secilenfakultebolum = new List<Bolum>();

            foreach (var item in bolumlistem)
            {
                if (item.FakulteAdi == gelenfakulte.FakulteAdi)
                {
                    //bolum listesi ile fakulte listesi kontrol edilmis olur
                    secilenfakultebolum.Add(item);
                }
            }
            return secilenfakultebolum;
        }

    }
}