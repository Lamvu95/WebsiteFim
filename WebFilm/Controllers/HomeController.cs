using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFilm.Models;

namespace WebFilm.Controllers
{
    public class HomeController : Controller
    {
        WebFilmEntities2 db = new WebFilmEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Slider_PartialView()
        {
            var listSlider = db.Table_Fim.Where(r => r.Slide == "Yes").Take(3).ToList();
            return PartialView(listSlider);
        }
        public PartialViewResult Phimmoi_Partial()
        {
            var listPhimMoi = db.Table_Fim.Where(r => r.NamSanXuat == 2017).Take(6).ToList();
            return PartialView(listPhimMoi);
        }
        public PartialViewResult HotMovie_PartialView()
        {
            var listHotMovie = db.Table_Fim.Where(r => r.Rating == "9 sao").Take(4).ToList();
            return PartialView(listHotMovie);
        }
        public PartialViewResult PhimBoHot_PartialView()
        {
            var listPBHOT = db.Table_Fim.Where(r => r.Rating == "8.5 sao").Take(4).ToList();
            return PartialView(listPBHOT);
        }
        public ViewResult phim(int id = 0)
        {
            var film = db.Table_Fim.Where(r => r.IDFim == id).First();
            if (film == null) { ViewBag.FilmTitle = "Not found"; Response.StatusCode = 404; }
            else ViewBag.FilmTitle = film.NameFim;
            ViewBag.Id = id;

            return View(film);
        }
        public ViewResult watching(int id = 0)
        {
            var film = db.Table_Fim.Where(r => r.IDFim == id).First();
            if (film == null) { ViewBag.FilmTitle = "Not found"; Response.StatusCode = 404; }
            else ViewBag.FilmTitle = film.NameFim;
            ViewBag.Id = id;

            return View(film);
        }

        public ViewResult PhimHanhDong(int id = 1)
        {
            var PhimHanhDong = db.Table_Fim.Where(r => r.IDTheLoai == id).ToList();
            //if (film == null) { ViewBag.FilmTitle = "Not found"; Response.StatusCode = 404; }
            //else ViewBag.FilmTitle = film.NameFim;
            ViewBag.Id = id;

            return View(PhimHanhDong);


        }

        public ViewResult PhimHaiHuoc(int id = 2)
        {
            var PhimHaiHuoc = db.Table_Fim.Where(r => r.IDTheLoai == id).ToList();
            //if (film == null) { ViewBag.FilmTitle = "Not found"; Response.StatusCode = 404; }
            //else ViewBag.FilmTitle = film.NameFim;
            ViewBag.Id = id;

            return View(PhimHaiHuoc);


        }
        public ViewResult PhimTinhCam(int id = 3)
        {
            var PhimTinhCam = db.Table_Fim.Where(r => r.IDTheLoai == id).ToList();
            //if (film == null) { ViewBag.FilmTitle = "Not found"; Response.StatusCode = 404; }
            //else ViewBag.FilmTitle = film.NameFim;
            ViewBag.Id = id;

            return View(PhimTinhCam);


        }
        public ViewResult PhimKhoaHoc(int id = 1)
        {
            var PhimKhoaHoc = db.Table_Fim.Where(r => r.IDTheLoai == id).ToList();
            //if (film == null) { ViewBag.FilmTitle = "Not found"; Response.StatusCode = 404; }
            //else ViewBag.FilmTitle = film.NameFim;
            ViewBag.Id = id;

            return View(PhimKhoaHoc);


        }

        public PartialViewResult Menutrai_PartialView()
        {
            var Menutrai = db.Table_Fim.Where(r => r.Rating == "9 sao").Take(8).ToList();
            return PartialView(Menutrai);
        }
        public PartialViewResult PhimLienQuan_Partial()
        {
            var PhimLienQuan = db.Table_Fim.Where(r => r.IDTheLoai == 1).Take(4).ToList();
            return PartialView(PhimLienQuan);
        }
        public ActionResult timkiem(string SearchText)
        {

            if (!string.IsNullOrEmpty(SearchText))
            {
                var result = db.Table_Fim.Where(s => s.NameFim.Contains(SearchText));
                return View(result.ToList());
            }
            return View(db.Table_Fim);
        }
    }
}