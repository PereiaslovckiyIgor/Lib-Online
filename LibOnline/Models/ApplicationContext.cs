﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibOnline.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Categories.AllCategories> allCategories { get; set; }
        public DbSet<BooksCategories.BooksCategories> booksCategories { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }//ApplicationContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = IGORPC\MSSQL_IGOR; Database = LibOnline; User ID = sa; Password = 793638bujhm; MultipleActiveResultSets=true;");
        }//OnConfiguring


    }//ApplicationContext
}
