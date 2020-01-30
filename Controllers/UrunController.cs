using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UrunKatalog.Entity;

namespace UrunKatalog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UrunController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Urun
        public ActionResult Index()
        {
            var urunler = db.Urunler.Include(u => u.Kategori);
            return View(urunler.ToList());
        }

        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urunler.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        public ActionResult Ekle()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "Id,UrunAdi,UrunAciklama,UrunFiyat,UrunStok,UrunResim,UrunSatistami,UrunAnasayfa,KategoriId")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urunler.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

 
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urunler.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

        // POST: Urun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "Id,UrunAdi,UrunAciklama,UrunFiyat,UrunStok,UrunResim,UrunSatistami,UrunAnasayfa,KategoriId")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urunler.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Urun/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilOnay(int id)
        {
            Urun urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
