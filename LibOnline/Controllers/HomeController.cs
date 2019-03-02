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
using System.Data.SqlClient;

namespace LibOnline.Controllers
{
    public class HomeController : Controller
    {
        // Начальная инициализация страницы
        // Состоит из 3 частей: Популярние книги, Новые книги, Недавно добавленные книги
        public IActionResult Index()
        {

            var populars = getPopulars();
            var newBooks = getNewBooks();


            ViewBag.popularBooks = BooksGrouping(populars);
            ViewBag.newBooks = BooksGrouping(newBooks);

            return View();
        }//Index

        // Получит все жанры книг
        public JsonResult GetAllCategories()
        {
            List<AllCategories> list = new List<AllCategories>();
            using (ApplicationContext db = new ApplicationContext())
                list = db.allCategories.FromSql("EXECUTE [general].[GetAllCategories]").ToList();

            return Json(list);
        }//GetAllCategories



        // Вспомготальный метод. Нужен для добавления автора в книгу, в том случае, если авторов несколько.
        // В MS SQL возникает проблема со связью 1 ко многим(1 книга, несколько авторов) и проиходит дублирование данных
        private List<BooksCatogoriesToShow> BooksGrouping(List<BooksCategories> populars) {

            List<BooksCatogoriesToShow> booksToShow = new List<BooksCatogoriesToShow>();

            foreach (var item in populars)
            {
                int tmpBookIndex = booksToShow.FindIndex(i => i.IdBook == item.IdBook);

                if (tmpBookIndex == -1)
                    booksToShow.Add(new BooksCatogoriesToShow(item));
                else
                (booksToShow.Find(i => i.IdBook == item.IdBook)).AddAuthor(item.IdAuthor, item.AuthorFullName);
            }//foreach


            return booksToShow;
        }//BooksGrouping


        private List<BooksCategories> getPopulars() {
            List<BooksCategories> populars = new List<BooksCategories>();

            using (ApplicationContext db = new ApplicationContext())
                populars = db.booksCategories.FromSql("EXECUTE [books].[GetPopularBooksByRating]").ToList();


            return populars;
        }


        private List<BooksCategories> getNewBooks()
        {
            List<BooksCategories> newBooks = new List<BooksCategories>();

            using (ApplicationContext db = new ApplicationContext())
                newBooks = db.booksCategories.FromSql("EXECUTE [books].[GetNewBooksByReleasedDate]").ToList();

            return newBooks;
        }

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
