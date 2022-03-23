using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepositories<TblEgitimlerim> repo = new GenericRepositories<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                
                    return View("EgitimEkle");
            }
                else
                {
                    repo.TAdd(p);
                    return RedirectToAction("Index");
                }
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
       [HttpGet]
       public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {

                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x => x.ID == p.ID);
            egitim.ALTBASLIK1= p.ALTBASLIK1 ;
            egitim.BASLIK= p.BASLIK ;
            egitim.ALTBASLIK2= p.ALTBASLIK2;
            egitim.GNO= p.GNO;
            egitim.TARIH= p.TARIH;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}