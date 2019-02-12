using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibOnline.Models;
using LibOnline.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace LibOnline.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //List<CategoryImage> list = new List<CategoryImage>();
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    list = db.CategoryImages.FromSql("EXECUTE [library].[CategoriesImagesSelect]").ToList();
            //    list.ForEach(i=>i.UpdateImgPath());
            //}//using


            //ViewBag.CategoryImages = list;
            return View();
        }//Index

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
