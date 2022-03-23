using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepositories<TblSertifikalarım> repo = new GenericRepositories<TblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaDuzenle(int id)
        {
            var sertifika = repo.Find(x=>x.ID==id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaDuzenle(TblSertifikalarım t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Tarih = t.Tarih;
            sertifika.ACIKLAMA = t.ACIKLAMA;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}