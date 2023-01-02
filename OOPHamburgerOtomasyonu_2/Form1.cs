using OOPHamburgerOtomasyonu_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPHamburgerOtomasyonu_2
{
    public partial class Form1 : Form
    {

        /*
         
         Tag Property'si

        İstisnasız her kontrolün bir Tag Property'si vardır...Bu property kontollerek özgü özel bir veri saklamak istedigimizde cok işimize yarar...Tag property'si object tipinde deger alır...Siz bu kontrole dolayısıyla istediginiz her tipte deger yazabilirsiniz...Tag'i kontrolün tasıdıgı canta olarak düsünebilirsiniz...
         
         
         
         
         */






        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hamburger menülerini listemize object Initializer yöntemi ile ekleyecegiz...

            List<HamburgerMenusu> menuler = new List<HamburgerMenusu>
            {
                new HamburgerMenusu{Ad = "Texas SmokeHouse",Fiyat = 15,Aciklama = "Gurme menusunden enfes bir lezzet"},
                new HamburgerMenusu{Ad="Barbekü Brioche",Fiyat = 18, Aciklama = "Barbekülü bir meksika ateşine hazır mısınız"},
                new HamburgerMenusu{Ad = "Crispy Chicken",Fiyat = 20, Aciklama = "Tavuklar hic bu kadar cıtır olmamıstı"},
                new HamburgerMenusu{Ad = "SteakHouse",Fiyat = 25,Aciklama = "Steak işte"},
                new HamburgerMenusu{Ad = "TenderCrisp",Fiyat = 30,Aciklama = "Cıtırlı bir acı"}
            };


            //foreach (HamburgerMenusu item in menuler)
            //{
            //    cmbMenu.Items.Add(item);
            //}

            cmbMenu.DataSource = menuler;
            cmbMenu.SelectedIndex = -1;

           
        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedItem != null)
                lblAciklama.Text = (cmbMenu.SelectedItem as HamburgerMenusu).Aciklama;
            else lblAciklama.Text = "";


            //try
            //{
            //    lblAciklama.Text = (cmbMenu.SelectedItem as HamburgerMenusu).Aciklama;
            //}
            //catch (Exception)
            //{

            //    lblAciklama.Text = "";
            //}
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Siparis s = new Siparis();
            s.Ad = txtIsim.Text;
            if (cmbMenu.SelectedItem == null) 
            {
                MessageBox.Show("Lütfen kafanıza göre menü girmeyiniz veya menü seciniz");
                return;
            }

          
           
            s.SecilenMenu = cmbMenu.SelectedItem as HamburgerMenusu;

            s.Adet = Convert.ToInt16(nmrAdet.Value);

            if (rdbBuyuk.Checked) s.Buyukluk = Enums.Boyut.Buyuk;
            else if (rdbOrta.Checked) s.Buyukluk = Enums.Boyut.Orta;

            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                {
                    EkstraMalzeme eks = new EkstraMalzeme(); //EkstraMalzeme sınıfının instance'ini aldık
                    eks.Ad = item.Text;
                    eks.Fiyat = Convert.ToDecimal(item.Tag); //Fiyatı checkbox kontrolünün Tag property'sinden aldık...Tag özelligi bir kontrolün icerisinde istedigimiz tipte(object tipte deger aldıgı icin) deger tutmamızı saglar...O kontrolün deger tasıabilcegi özel bir alanı olarak düsünebilirsiniz...Ancak object deger oldugu icin boxing ve unboxing olayını unutmamamız gerekir...
                    s.Malzemeleri.Add(eks);
                }
            }

            

            s.TutarHesapla(); //Siparişin tutarının hesaplanması icin bunu yapmalısınız yoksa hesaplanmaz...

            lstSiparisler.Items.Add(s);
        }

        private void btnCiro_Click(object sender, EventArgs e)
        {
           
            //Tıklandıgım ana kadar almıs oldugum tüm siparişlerin toplam fiyatını MessageBox ile gösterin...

            decimal toplam = 0;

            foreach (Siparis item in lstSiparisler.Items)
            {
                toplam += item.Fiyat;
            }

            MessageBox.Show(toplam.ToString());
        }
    }
}
