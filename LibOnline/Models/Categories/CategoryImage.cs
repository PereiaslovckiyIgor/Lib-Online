using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibOnline.Models.Categories
{
    public class CategoryImage
    {
        // Поля для обьекта из процедуры
        [Key]
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }


        // Локальный путь к папке с файлом, инициируется конструктором
        private string lockalPath = @"/images/Categiries/";

        public void UpdateImgPath()
        {
            ImagePath = lockalPath + ImagePath;
        }//UpdateImgPath


    }//CategoryImage
}//CategoryImage
