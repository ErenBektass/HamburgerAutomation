using OOPHamburgerOtomasyonu_2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHamburgerOtomasyonu_2.Models
{
    public class Siparis : BaseEntity
    {
        public Siparis()
        {
            Malzemeleri = new List<EkstraMalzeme>();
        }
        public HamburgerMenusu SecilenMenu { get; set; }
        public short Adet { get; set; }
        public Boyut Buyukluk { get; set; }
        public List<EkstraMalzeme> Malzemeleri { get; set; }

        //BUrada array yerine List kullanma nedenimiz ilgilendigimiz property'nin icerisine alacagı degerlerin sayısının degişken olmasıdır...Yani buradaki koleksiyon fixed degildir...Eger Array kullansaydık bu array sürekli modifiye edilmek zorunda kalacak ve hem sisteme hem de bize zahmet cıkaracaktır...List bizi bu durumdan kurtarır...


        //Customized Encapsulation

       // public decimal ToplamTutar { get; private set; } //burada set'in dısarıdan atanmasını engelliyoruz...ToplamTutar isimli property'e sadece burada atanma yapılabilir... Bunu Siparis'in kendi Fiyat özelliginde de lütfen yapınız...


        public void TutarHesapla()
        {
            Fiyat = SecilenMenu.Fiyat; //Siparişimiz bir HambugerMenusu tipindeki property'si aracılıgı ile kullanıcı tarafından secilen menünün fiyatına ulasıp ToplamTutar'ına önce o fiyatın atanmasını TutarHesapla() metodunun ilk görevi olarak yapacak...
            switch (Buyukluk)
            {

                case Boyut.Orta:
                    Fiyat += 1;
                    break;
                case Boyut.Buyuk:
                    Fiyat += 2;
                    break;

            }

            foreach (EkstraMalzeme item in Malzemeleri)
            {
                Fiyat += item.Fiyat;

            }

            Fiyat *= Adet;



        }

        public override string ToString()
        {
            if (Malzemeleri.Count < 1)
            {
                //Eger Kullanıcı malzeme secmemişse bu malzemeler yazılmadan direkt menü yazdırılsın istiyoruz...

                return $"{Ad} kişisine : {SecilenMenu.Ad} Menüsü, x {Adet}, {Buyukluk} boy, Toplam: {Fiyat:C2}";
            }

            //Kullanıcının sectigi malzemelerin isimlerini de göstermek istiyoruz

            string malzemesi = null;

            //Döngümüz burada koleksiyondaki malzemelerin isimlerini yakalayarak yukarıdaki metinsel tipteki degişkenimize atacak

            foreach (EkstraMalzeme item in Malzemeleri)
            {
                //Her gelen item bir Ekstra Malzeme tipindedir

                malzemesi += $"{item.Ad},";
            }
            
            //ketcap,mayonez,acısos,
            malzemesi = malzemesi.TrimEnd(','); //TrimEnd metodu bir metnin sonundaki bir karakteri silmekle görevlidir...

            return $"{Ad} kişisine : {SecilenMenu.Ad} Menüsü,x {Adet}, {Buyukluk} boy, Malzemeler: ({malzemesi}), Toplam Tutar => {Fiyat:C2}";


        }

    }
}
