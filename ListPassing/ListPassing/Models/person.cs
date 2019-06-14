using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListPassing.Models
{
    public class person
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
    }
    public class PersonMUL
    {
        public IEnumerable<person> PersonList { get; set; }

    }
}