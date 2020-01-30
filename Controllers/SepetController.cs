using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunKatalog.Entity;
using UrunKatalog.Models;

namespace UrunKatalog.Controllers
{
    public class SepetController : Controller
    {
        private DataContext db = new DataContext();
        public Sepet SepetGetir()
        {
            Sepet sepet = (Sepet)Session["sepet"]; //Sepet daha önce oluşturulmuşmu ona bakıp ona göre sepet oluşturuyoruz
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["sepet"] = sepet;
            }
            return sepet;
        }
        // GET: Sepet
        public ActionResult Index()
        {
            return View(SepetGetir());
        }

        public ActionResult SepeteEkle(int id)
        {
            var urun = db.Urunler.FirstOrDefault(i=>i.Id == id);
            if (urun != null)
            {
                SepetGetir().SepetEkle(urun,1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SepetCikar(int id)
        {
            var urun = db.Urunler.FirstOrDefault(i => i.Id == id);
            if (urun != null)
            {
                SepetGetir().SepetCikar(urun);
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult _SepetOzet()
        {
            return PartialView(SepetGetir());
        }

        public ActionResult SepetOdeme()
        {
            return View(new AdresDetaylari());
        }
        [HttpPost]
        public ActionResult SepetOdeme(AdresDetaylari model)
        {
            var sepet = SepetGetir();
            if (sepet.SepetAlisverisler.Count==0)
            {
                ModelState.AddModelError("","Sepetinizde Ürün Bulunmamakta");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    SiparisiKaydet(sepet, model);
                    sepet.SepetTemizle();
                    return View("SiparisTamam");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }

        private void SiparisiKaydet(Sepet sepet, AdresDetaylari model)
        {
            var siparis = new Siparis();
            siparis.SiparisNumarasi ="A"+ (new Random()).Next(11111, 99999).ToString();
            siparis.OdemeMiktari = sepet.SepetFiyat();
            siparis.SiparisTarihi = DateTime.Now;
            siparis.SiparisDurumu = EnumSiparisDurum.OnayBekliyor;

            siparis.KullaniciAdi = User.Identity.Name;
            siparis.AdresBaslik = model.AdresBaslik;
            siparis.Adres = model.Adres;
            siparis.Sehir = model.Sehir;
            siparis.İlce = model.İlce;
            siparis.Mahalle = model.Mahalle;
            siparis.PostaKodu = model.PostaKodu;

            siparis.SiparisDetaylari = new List<SiparisDetay>();
            foreach (var item in sepet.SepetAlisverisler)
            {
                SiparisDetay siparisdetay = new SiparisDetay();
                siparisdetay.SiparisMiktar = item.SiparisAdet;
                siparisdetay.UrunFiyat = item.SiparisAdet * item.Urun.UrunFiyat;
                siparisdetay.UrunId = item.Urun.Id;

                siparis.SiparisDetaylari.Add(siparisdetay);
            }
            db.Siparisler.Add(siparis);
            db.SaveChanges();
        }
    }
}