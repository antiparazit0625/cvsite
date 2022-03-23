using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepositories<TblLogın> repo = new GenericRepositories<TblLogın>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblLogın p)
        {

            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            TblLogın t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TblLogın t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Duzenle(TblLogın p)
        {
            TblLogın t = repo.Find(x => x.ID == p.ID);
            t.KullanıcıAdi = p.KullanıcıAdi;
            t.Sifre = p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
  }