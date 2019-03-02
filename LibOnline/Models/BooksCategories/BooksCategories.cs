using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LibOnline.Models.Authors;

namespace LibOnline.Models.BooksCategories
{
    public class BooksCategories
    {
        [Key]
        public int IdBook { get; set; }
        public string BookName { get; set; }
        public int IdAuthor { get; set; }
        public string AuthorFullName { get; set; }
        public int RatingValue { get; set; }
        public string ImagePath { get; set; }

    }//BooksCategories




    public class BooksCatogoriesToShow
    {
        public int IdBook { get; set; }
        public string BookName { get; set; }
        public List<Author> BookAuthors { get; set; }
        public int RatingValue { get; set; }
        public string ImagePath { get; set; }

        public BooksCatogoriesToShow(BooksCategories item)
        {
            BookAuthors = new List<Author>();

            IdBook = item.IdBook;
            BookName = item.BookName;
            RatingValue = item.RatingValue;
            ImagePath = item.ImagePath;
            BookAuthors.Add(new Author(item.IdAuthor, item.AuthorFullName));
        }//c-tor

        public void AddAuthor(int IdAuthor, string AuthorFullName) {
            BookAuthors.Add(new Author(IdAuthor, AuthorFullName));
        }//AddAuthor

    }//BooksCatogoriesToShow
}
