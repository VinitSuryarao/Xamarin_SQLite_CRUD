using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLite_Example
{
    public class Employer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
      
    }
}
