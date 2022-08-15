using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Model
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
