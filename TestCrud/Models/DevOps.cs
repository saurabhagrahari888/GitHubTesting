using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCrud.Models
{
    public class DevOps
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaskDate { get; set; }
      //  public string Source { get; set; }
          public List<SelectListItem> Source { get; set; }
        public string SprintName { get; set; }
        public List<object> SprintName1 { get; set; }
        public int Pbid { get; set; }
        public List<int> Pbid1 { get; set; }
        public string HdName { get; set; }
      //  public string IncidentNumber { get; set; }
        public int Workorder { get; set; }
        public string Workorder1 { get; set; }
        public Dictionary<object, object> Description1 { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public string SourceEmailDate { get; set; }
        public List<object> TimesheetEmpName { get; set; }
    }
}