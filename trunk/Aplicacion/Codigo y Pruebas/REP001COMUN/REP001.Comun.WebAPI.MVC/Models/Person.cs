using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REP001.Comun.WebAPI.MVC.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateBird { get; set; }
    }
}