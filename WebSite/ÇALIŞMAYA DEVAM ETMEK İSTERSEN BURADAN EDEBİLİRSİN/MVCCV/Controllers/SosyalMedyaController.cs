using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Repositories;
using MVCCV.Models.Entity;
namespace MVCCV.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepositories<sosyalmedya> repo = new GenericRepositories<sosyalmedya>();
            public ActionResult Index()
        {
            var social = repo.List();
            return View(social);
        }
        [HttpGet]
        public ActionResult Ekle(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult Ekle(sosyalmedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(sosyalmedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.ad = p.ad;
            hesap.link = p.link;
            hesap.ikon = p.ikon;
            hesap.Durum = true;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

    }
}