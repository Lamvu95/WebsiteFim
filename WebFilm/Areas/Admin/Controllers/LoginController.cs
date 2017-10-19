using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebFilm.Models;
namespace WebFilm.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        WebFilmEntities2 db = new WebFilmEntities2();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Table_Username user)
        {
            var username = user.NameUser;
            var pass = user.PassUser;
            var check = db.Table_Username.Any(r => r.NameUser == username&&r.PassUser==pass);
            if (check)
            {
                return RedirectToAction("index", "Home");
            }
            ViewBag.Message = "Username or password is incorrect!";
            return View();
        }
    }
}