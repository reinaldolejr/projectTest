using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Model
{
    public class ProductModel
    {
        //[PrimaryKey, AutoIncrement]
        //[Column("Id")]
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public RatingModel rating { get; set; }

    }
}
