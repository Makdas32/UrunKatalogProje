using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunKatalog.Entity;

namespace UrunKatalog.Models
{
    public class SiparisDetayModel
    {
        public int SiparisId { get; set; }
        public string SiparisNumarasi { get; set; }
        public double OdemeMiktari { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public EnumSiparisDurum SiparisDurumu { get; set; }

        public virtual List<SiparisDetayLine> SiparisDetaylar { get; set; }


        public string AdresBaslik { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string İlce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
    }

    public class SiparisDetayLine
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }

        public int SiparisMiktar { get; set; }
        public double UrunFiyat { get; set; }
        public string UrunResim { get; set; }

        //Urun ile ilişkiler

    }
}