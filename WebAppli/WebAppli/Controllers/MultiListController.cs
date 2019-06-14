using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppli.Controllers
{
    public class MultiListController : Controller
    {
        // GET: MultiList
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int? id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewList()
        {
            List<tstclass> objtestclasslist = new List<tstclass>();
            objtestclasslist.Add(new tstclass(1, "TestName1", "TestAddress1"));
            objtestclasslist.Add(new tstclass(2, "TestName2", "TestAddress2"));
            objtestclasslist.Add(new tstclass(3, "TestName3", "TestAddress3"));
            objtestclasslist.Add(new tstclass(4, "TestName4", "TestAddress4"));
            objtestclasslist.Add(new tstclass(5, "TestName5", "TestAddress5"));
            objtestclasslist.Add(new tstclass(6, "TestName6", "TestAddress6"));
            objtestclasslist.Add(new tstclass(7, "TestName7", "TestAddress7"));
            return View(objtestclasslist);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<tstclass> objtestclasslist = new List<tstclass>();
            objtestclasslist.Add(new tstclass(1, "TestName1", "TestAddress1"));
            objtestclasslist.Add(new tstclass(2, "TestName2", "TestAddress2"));
            objtestclasslist.Add(new tstclass(3, "TestName3", "TestAddress3"));
            objtestclasslist.Add(new tstclass(4, "TestName4", "TestAddress4"));
            objtestclasslist.Add(new tstclass(5, "TestName5", "TestAddress5"));
            objtestclasslist.Add(new tstclass(6, "TestName6", "TestAddress6"));
            objtestclasslist.Add(new tstclass(7, "TestName7", "TestAddress7"));
            var data = objtestclasslist.Where(x => x.Id == id).FirstOrDefault();
            tstclass objclass = new tstclass(data.Id, data.Name, data.Address);
            objclass.Id = data.Id;
            objclass.Name = data.Name;
            objclass.Address = data.Address;

            return View();
        }

      
    }
    public class tstclass
    {
        private int id;
        private string name;
        private string address;
        public tstclass()
        {


        }
        public tstclass(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;

        }
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
    }
}