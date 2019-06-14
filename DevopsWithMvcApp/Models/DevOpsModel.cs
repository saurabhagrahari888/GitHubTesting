using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevopsWithMvcApp.Models
{
    public class DevOpsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaskDate { get; set; }
        public string Source { get; set; }
      //  public List<object> Source1 { get; set; }
        public string SprintName { get; set; }
        public List<object> SprintName1 { get; set; }
        public int Pbid { get; set; }
        public List<int> Pbid1 { get; set; }
        public string HdName { get; set; }
        public  int Workorder { get; set; }
        public List<object> Workorder1 { get; set; }
        public Dictionary<object,object> Description1 { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public string SourceEmailDate { get; set; }
    }
}