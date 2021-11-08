using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinRecipesApp.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TextA { get; set; }
        public string TextB { get; set; }
        public string TextC { get; set; }
        public string TextD { get; set; }
        public DateTime Date { get; set; }
    }
}
