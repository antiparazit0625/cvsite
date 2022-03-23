using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class HobilerController : Controller
    {
        GenericRepositories<TblHobilerim> repo = new GenericRepositories<TblHobilerim>();
        public ActionResult Index()
        {
            var hakkımda = repo.List();
            return View(hakkımda);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.ACIKLAMA1 = p.ACIKLAMA1;
            t.ACIKLAMA2 = p.ACIKLAMA2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}