using System.IO;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace Mvc.Controllers
{
    public class HakkimdaController : Controller
    {
        GenericRepositories<TblHakkımda> repo = new GenericRepositories<TblHakkımda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TblHakkımda p)
        {
           if (Request.Files.Count > 0)
            {

                System.IO.File.Delete(Server.MapPath("~/startbootstrap-resume-gh-pages/assets/img/resim.jpg"));
                string yol = "~/startbootstrap-resume-gh-pages/assets/img/" + "resim.jpg";
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.RESIM = "/startbootstrap-resume-gh-pages/assets/img/" + "resim.jpg";
            }
            var t = repo.Find(x => x.ID == 1);
            t.AD = p.AD;
            t.SOYAD = p.SOYAD;
            t.TELEFON = p.TELEFON;
            t.MAIL = p.MAIL;
            t.RESIM = p.RESIM;
            t.ACİKLAMA = p.ACİKLAMA;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}