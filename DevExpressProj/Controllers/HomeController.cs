using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using DevExpressProj.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;

namespace DevExpressProj.Controllers
{
    public class HomeController : Controller
    {
        SaurabhEntities objdb = new SaurabhEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TestDevExpress()
        {
            // var data = objdb.Employees.Select(t => t).ToList();
            return View();
        }
        public ActionResult testResult(DataSourceLoadOptions loadOptions)
        {
            string orderByClause = "";
            string orderbydesc = "";
            List<Employee> objlst = new List<Employee>();
            if (loadOptions.Sort != null)
            {
                foreach (var item in loadOptions.Sort)
                {
                    var selectorName = item.Selector;
                    var descbool = item.Desc;
                    string desctest = descbool.ToString();
                    if (desctest == "False")
                    {
                        orderbydesc = " " + "Asc";
                    }
                    else
                    {
                        orderbydesc = " " + "Desc";
                    }
                    orderByClause =  selectorName;
                }
            }
            DataTable dt = new DataTable();
            string connetionString = "Data Source=192.168.110.65;Initial Catalog=Saurabh;User Id = ODC; Password = ODC#01";
            int skip = loadOptions.Skip;
            int take = loadOptions.Take;
            //string queryString = "select * from Employee order by " + orderByClause + " " + orderbydesc + " Offset " + skip + " ROWS Fetch next " + take + " ROWS ONLY";
            string queryString = "select * from Employee ";
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            var aa = dt.AsEnumerable().Select(r => new Employee()
            {
                EmployeeId = (int)r["EmployeeId"],
                FirstName = (string)r["FirstName"],
                LastName = (string)r["LastName"],
                EmployeeCode = (string)r["EmployeeCode"],
                Position = (string)r["Position"],
                Office = (string)r["Office"]
            });
            var result = DataSourceLoader.Load(aa, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);
        }
        
        //var result = DataSourceLoader.Load(objdb.Employees, loadOptions);
        //    var resultJson = JsonConvert.SerializeObject(result);
        //    return Content(resultJson);         

        [HttpPut]
        public ActionResult TestEditResult(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");
            var employee = objdb.Employees.First(e => e.EmployeeId == key);
            JsonConvert.PopulateObject(values, employee);
            if (!ModelState.IsValid)
                objdb.SaveChanges();
            return Content("Test Employee!!!!!");
        }

        [HttpGet]
        public ActionResult TaskDetails(int id, DataSourceLoadOptions loadOptions)
        {
            //DataTable dt = new DataTable();
            //string connetionString = "Data Source=192.168.110.65;Initial Catalog=Saurabh;User Id = ODC; Password = ODC#01";
            //string queryString = "select * from EmployeeAcademics where RefempId = " + id;
            //SqlConnection connection = new SqlConnection(connetionString);
            //SqlCommand command = new SqlCommand(queryString, connection);
            //connection.Open();
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //var aa = dt.AsEnumerable().Select(r => new EmployeeAcademic()
            //{
            //    Acdid = (int)r["Acdid"],
            //    RefempId = (int)r["RefempId"],
            //    HSC = (string)r["HSC"],
            //    SSC = (string)r["SSC"],
            //    Graduate = (string)r["Graduate"],
            //    PostGraduate = (string)r["PostGraduate"]
            //});
            //var result = DataSourceLoader.Load(aa, loadOptions);
            //var resultJson = JsonConvert.SerializeObject(result);
            //return Content(resultJson);

            var testEf = objdb.EmployeeAcademics.Where(a => a.RefempId == id).Select(t => t).ToList();
            EmployeeAcademic objea = new EmployeeAcademic();
            List<EmployeeAcademic> objlst = new List<EmployeeAcademic>();
            foreach (var item in testEf)
            {
                objea.Acdid = item.Acdid;
                objea.RefempId = item.RefempId;
                objea.HSC = item.HSC;
                objea.SSC = item.SSC;
                objea.Graduate = item.Graduate;
                objea.PostGraduate = item.PostGraduate;
                objlst.Add(objea);
            }

            var result = DataSourceLoader.Load(objlst, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);

        }


    }

}
