using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
}
