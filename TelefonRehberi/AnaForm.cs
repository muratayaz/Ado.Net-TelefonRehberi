using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int ReturnValue = bll.KayitEkle(txtIsim.Text, txtSoyisim.Text, txtTelefonI.Text, txtTelefonII.Text, txtTelefonIII.Text, txtEmailAdres.Text, txtWebSite.Text, txtAdres.Text, txtAciklama.Text);

            if (ReturnValue > 0)
            {
                ListeDoldur();
                MessageBox.Show("Kaydınız başarılı bir şekilde eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt ekleme işleminde hata oluştu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            ListeDoldur();
        }
        private void ListeDoldur()
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            List<Rehber> RehberListesi = bll.KayitListe();
            if (RehberListesi != null && RehberListesi.Count > 0)
            {
                lstListe.DataSource = RehberListesi;
            }
        }

        private void lstListe_DoubleClick(object sender, EventArgs e)
        {
            ListBox L = (ListBox)sender;
            Rehber SecilenKayit = (Rehber)L.SelectedItem;
            txtIsim.Text = SecilenKayit.Isim;
            txtSoyisim.Text = SecilenKayit.Soyisim;
            txtTelefonI.Text = SecilenKayit.TelefonNumarasiI;
            txtTelefonII.Text = SecilenKayit.TelefonNumarasiII;
            txtTelefonIII.Text = SecilenKayit.TelefonNumarasiIII;
            txtEmailAdres.Text = SecilenKayit.EmailAdres;
            txtAdres.Text = SecilenKayit.Adres;
            txtWebSite.Text = SecilenKayit.WebAdres;
            txtAciklama.Text = SecilenKayit.Aciklama;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            Rehber K = (Rehber)lstListe.SelectedItem;
            int ReturnValue = bll.KayitDüzenle(K.KullaniciID, txtIsim.Text, txtSoyisim.Text, txtTelefonI.Text, txtTelefonII.Text, txtTelefonIII.Text, txtEmailAdres.Text, txtWebSite.Text, txtAdres.Text, txtAciklama.Text);
            if (ReturnValue > 0)
            {
                MessageBox.Show("Kaydınız başarılı bir şekilde güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeDoldur();
            }
            else
            {
                MessageBox.Show("Kayıt güncelleme işleminde hata oluştu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult SilmeIslemiCevap = MessageBox.Show("Silmek istediğinize emin misiniz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (SilmeIslemiCevap == DialogResult.Yes)
            {
                BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
                Guid SilinecekID = ((Rehber)lstListe.SelectedItem).KullaniciID;
                int ReturnValue = bll.KayitSil(SilinecekID);
                if (ReturnValue > 0)
                {
                    ListeDoldur();
                    MessageBox.Show("Kaydınız başarılı bir şekilde silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    MessageBox.Show("Kayıt silme işleminde hata oluştu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstListe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
