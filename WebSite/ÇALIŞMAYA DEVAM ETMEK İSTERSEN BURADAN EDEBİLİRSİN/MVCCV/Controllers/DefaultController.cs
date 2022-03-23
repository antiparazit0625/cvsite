using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities CV = new DbCVEntities();
        public ActionResult Index()
        {
            var hakkimda = CV.TblHakkımda.ToList();
            return View(hakkimda);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = CV.TblDeneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult SosyalMedya()
        {
            var SosyalMedya = CV.sosyalmedya.Where(x=>x.Durum==true).ToList();
            return PartialView(SosyalMedya);
        }
        public PartialViewResult Egitimler()
        {
            var egitimlerims = CV.TblEgitimlerim.ToList();
            return PartialView(egitimlerims);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerims = CV.TblYeteneklerim.ToList();
            return PartialView(yeteneklerims);
        }
        public PartialViewResult hobilerim()
        {
            var hobiler = CV.TblHobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult sertifikalarım()
        {
            var sertifika = CV.TblSertifikalarım.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(TblIletısım t)
        {
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            CV.TblIletısım.Add(t);
            CV.SaveChanges();
            return PartialView();
        }
    }
}
