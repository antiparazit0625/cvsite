using MVCCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblLogın p)
        {
            DbCVEntities vt = new DbCVEntities();
            var bilgi = vt.TblLogın.FirstOrDefault(x => x.KullanıcıAdi == p.KullanıcıAdi && x.Sifre == p.Sifre);
            if(bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullanıcıAdi, false);
                Session["KullanıcıAdi"] = bilgi.KullanıcıAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}