using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunKatalog.Entity;

namespace UrunKatalog.Models
{
    public class Sepet //Burda static sınıf yapsaydık bütün kullanıcılar aynı sepeti kullanırdı.O yüzden static yapmıyoruz
    {
        private List<SepetAlisveris> _sepetAlisveris = new List<SepetAlisveris>();
        public List<SepetAlisveris> SepetAlisverisler
        {
            get { return _sepetAlisveris; }
        }

        public void SepetEkle(Urun urun,int siparisadet)
        {
            var urunvarmi = _sepetAlisveris.FirstOrDefault(i => i.Urun.Id == urun.Id);
            if (urunvarmi == null)
            {
                _sepetAlisveris.Add(new SepetAlisveris() {Urun = urun,SiparisAdet = siparisadet});
            }
            else
            {
                urunvarmi.SiparisAdet += siparisadet;
            }
        }
        public void SepetCikar(Urun urun)
        {
            _sepetAlisveris.RemoveAll(i => i.Urun.Id == urun.Id);
        }

        public double SepetFiyat()
        {
            return _sepetAlisveris.Sum(i=>i.Urun.UrunFiyat * i.SiparisAdet );
        }

        public void SepetTemizle()
        {
            _sepetAlisveris.Clear();
        }
    }

    public class SepetAlisveris
    {
        public Urun Urun { get; set; }
        public int SiparisAdet { get; set; }
    }
}