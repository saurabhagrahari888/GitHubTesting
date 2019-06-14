using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExpressProj.Models
{
    public class EmployeeNew
    {
     
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        public string Office
        {
            get;set;
        }
            public string EmployeeCode { get; set; }
            public string Position { get; set; }
    }
}