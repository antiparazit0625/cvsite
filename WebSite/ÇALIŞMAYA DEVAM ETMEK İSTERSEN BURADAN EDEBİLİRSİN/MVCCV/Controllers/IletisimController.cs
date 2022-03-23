using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class IletisimController : Controller
    {
        GenericRepositories<TblIletısım> repo=new GenericRepositories<TblIletısım>();
        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }
    }
}