using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UrunKatalog.Entity;
using UrunKatalog.Identity;
using UrunKatalog.Models;

namespace UrunKatalog.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        private DataContext db = new DataContext();

        [Authorize]
        public ActionResult Index()
        {
            var siparisler = db.Siparisler.Where(i => i.KullaniciAdi == User.Identity.Name)
                .Select(i => new KullaniciSiparisModel()
                {
                   Id = i.Id,
                   SiparisNumarasi = i.SiparisNumarasi,
                   OdemeMiktari = i.OdemeMiktari,
                   SiparisDurumu = i.SiparisDurumu,
                   SiparisTarihi = i.SiparisTarihi
                }).OrderByDescending(i => i.SiparisTarihi).ToList();
            return View(siparisler);
        }
        [Authorize]
        public ActionResult Detay(int id)
        {
            var model = db.Siparisler.Where(i => i.Id == id)
                .Select(i=> new SiparisDetayModel()
                {
                    SiparisId = i.Id,
                    SiparisNumarasi = i.SiparisNumarasi,
                    OdemeMiktari = i.OdemeMiktari,
                    SiparisDurumu = i.SiparisDurumu,
                    AdresBaslik = i.AdresBaslik,
                    Sehir = i.Sehir,
                    Adres = i.Adres,
                    Mahalle = i.Mahalle,
                    İlce = i.İlce,
                    PostaKodu = i.PostaKodu,
                    SiparisDetaylar = i.SiparisDetaylari.Select(x => new SiparisDetayLine() { 
                        UrunId = x.UrunId,
                        UrunAdi = x.Urun.UrunAdi.Length>50?x.Urun.UrunAdi.Substring(0,47)+"...":x.Urun.UrunAdi,
                        UrunResim = x.Urun.UrunResim,
                        SiparisMiktar = x.SiparisMiktar,
                        UrunFiyat = x.UrunFiyat
                    }).ToList()
                }).FirstOrDefault();
            return View(model);
        }


        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kayit(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                var kullanici = new ApplicationUser();
                kullanici.Name = model.İsim;
                kullanici.Surname = model.Soyad;
                kullanici.UserName = model.KullaniciAdi;
                kullanici.Email = model.Email;

               IdentityResult sonuc = userManager.Create(kullanici,model.Sifre);
                if (sonuc.Succeeded)
                {
                    if (roleManager.RoleExists("User")) //User diye bir rol olup olmadığını sorguluyoruz
                    {
                        userManager.AddToRole(kullanici.Id, "User"); //Kullanıcıyı User rolüne atadık
                    }
                    return RedirectToAction("Giris","Account");
                }
                else
                {
                    ModelState.AddModelError("KullaniciHata","Kayıt İşlemi Yapılamadı");
                }

            }
            return View(model);
        }

        public ActionResult Giris()
        {
            //var authManager = HttpContext.GetOwinContext().Authentication;
            //authManager.User.Identity.IsAuthenticated == true
            if (Request.IsAuthenticated) //Kullanıcı Giriş Yapmışsa
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(Giris model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var kullanici = userManager.Find(model.KullaniciAdi,model.Sifre);
                if (kullanici != null)
                {             
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = userManager.CreateIdentity(kullanici,"ApplicationCookie");  //Kullanıcı varsa cookie oluşturuyoruz
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.Hatirla; //Beni hatırla işaretliyse kalıcı cookie vermek için

                    authManager.SignIn(authProperties,identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl)) //Bunu yazmamızın sebebi giriş yapmadan girilemeyen yerden giriş sayfasına yönlendirilen kullanıcıyı giriş yaptıktan sonra direk girmek istediği yere göndermek
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı Bulunamadı.Kullanıcı Adınızı ve Şifrenizi Kontrol Ediniz");
                }
            }
            return View(model);
        }
        public ActionResult Cikis()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }

    }
}