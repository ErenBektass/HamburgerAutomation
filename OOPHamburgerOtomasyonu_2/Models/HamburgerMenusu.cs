using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHamburgerOtomasyonu_2.Models
{
    public class HamburgerMenusu : BaseEntity
    {
        public string Aciklama { get; set; }

        public override string ToString()
        {
            return $"{Ad} => {Fiyat:C2}"; //Fiyat:C2 ifadesi Fiyatın yanında işletim sisteminizin nation'ina göre döviz işareti cıkmasını saglar...
        }
    }
}
