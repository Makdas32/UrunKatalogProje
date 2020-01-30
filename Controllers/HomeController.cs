using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunKatalog.Entity;
using UrunKatalog.Models;

namespace UrunKatalog.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var urunler = db.Urunler.Where(i => i.UrunSatistami == true && i.UrunAnasayfa == true)
                .Select(
                  i => new UrunModel()
                  {
                      Id = i.Id,
                      UrunAdi = i.UrunAdi.Length > 50 ? i.UrunAdi.Substring(0, 47) + "..." : i.UrunAdi,
                      UrunAciklama = i.UrunAciklama.Length > 50 ? i.UrunAciklama.Substring(0, 47) + "..." : i.UrunAciklama,
                      UrunFiyat = i.UrunFiyat,
                      UrunStok = i.UrunStok,
                      UrunResim = i.UrunResim,
                      KategoriId = i.KategoriId
                  }).ToList();
            return View(urunler);
        }

        public ActionResult Detay(int id)
        {
            return View(db.Urunler.Where(i => i.Id == id).FirstOrDefault());
        }

        public ActionResult Liste(int? id)
        {
            var urunler = db.Urunler.Where(i => i.UrunSatistami == true)
                .Select(
                  i => new UrunModel()
                  {
                      Id = i.Id,
                      UrunAdi = i.UrunAdi.Length > 50 ? i.UrunAdi.Substring(0, 47) + "..." : i.UrunAdi,
                      UrunAciklama = i.UrunAciklama.Length > 50 ? i.UrunAciklama.Substring(0, 47) + "..." : i.UrunAciklama,
                      UrunFiyat = i.UrunFiyat,
                      UrunStok = i.UrunStok,
                      UrunResim = i.UrunResim ?? "1.jpg", //Resim boşsa 1.jpg atadık.Doluysa kendisi gelecek
                      KategoriId = i.KategoriId
                  }).AsQueryable(); //Sorguya aşağı if kısmı içinde devam edeceğimiz için asqueryable dedik
            if (id != null)
            {
                urunler = urunler.Where(i => i.KategoriId == id); //Bu kısmı yukarıdaki id ile eşleştirmemizin sebebi kategoriye göre listeleme yapmak
            }

            return View(urunler.ToList());
        }

        public PartialViewResult _KategoriListesi()
        {
            return PartialView(db.Kategoriler.ToList());
        }
    }
}