using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Model
{
    public class RatingModel
    {

        //[PrimaryKey, AutoIncrement]
        //[Column("Id")]
        public int id { get; set; }
        public decimal rate { get; set; }
        public int count { get; set; }
    }
}
