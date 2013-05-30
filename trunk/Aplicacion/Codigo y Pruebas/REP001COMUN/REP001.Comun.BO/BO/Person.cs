using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REP001.Comun.BO
{
    public class Person
    {
        public long? ID { get; set; }
        public string Name { get; set; }
        public DateTime? DateBird { get; set; }
        public int? Age { get { return ((int)((DateTime.Today.AddYears(1) - (DateTime)DateBird).TotalDays/ 365) - 1); } }

        public string LastName { get; set; }

        public string ImgUrl { get; set; }
        public byte[] Img { get; set; }
    }
}
