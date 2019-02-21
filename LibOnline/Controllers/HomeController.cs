using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibOnline.Models;
using LibOnline.Models.Categories;
using Microsoft.EntityFrameworkCore;
using LibOnline.Models.BooksCategories;

namespace LibOnline.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<BooksCategories> populars = new List<BooksCategories>();
            using (ApplicationContext db = new ApplicationContext())
                populars = db.booksCategories.FromSql("EXECUTE [books].[GetPopularBooksByRating]").ToList();



            ViewBag.popularBooks = populars;
            return View();
        }//Index


        public JsonResult GetAllCategories()
        {
            List<AllCategories> list = new List<AllCategories>();
            using (ApplicationContext db = new ApplicationContext())
                list = db.allCategories.FromSql("EXECUTE [general].[GetAllCategories]").ToList();

            return Json(list);
        }//GetAllCategories


        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
