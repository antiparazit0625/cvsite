using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepositories<TblYeteneklerim> repo = new GenericRepositories<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=>x.ID==id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim t)
        {
            var yet = repo.Find(x => x.ID == t.ID);
            yet.Yetenek = t.Yetenek;
            yet.Oran = t.Oran;
            repo.TUpdate(yet);
            return RedirectToAction("Index");
        }
    }
}