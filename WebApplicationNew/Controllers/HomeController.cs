using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using WebApplicationNew.Models;

namespace WebApplicationNew.Controllers
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
        public ActionResult testResult(DataSourceLoadOptions loadoptions)
        {
            //string orderByClause = "";
            //string orderbydesc = "";

            //List<Employee> objlst = new List<Employee>();

            //if (loadOptions.Sort != null)
            //{
            //    foreach (var item in loadOptions.Sort)
            //    {
            //        //  orderByClause = ", ColumnName DESC, ColumnName";
            //        var selectorName = item.Selector;
            //        var descbool = item.Desc;

            //        string desctest = descbool.ToString();

            //        if (desctest == "False")
            //        {
            //            orderbydesc = " " + "Asc";
            //        }
            //        else
            //        {
            //            orderbydesc = " " + "Desc";
            //        }
            //        orderByClause = "ORDER BY " + selectorName;


            //    }

            //}
            //DataTable dt = new DataTable();
            //string connetionString = "Data Source=192.168.110.65;Initial Catalog=Saurabh;User Id = ODC; Password = ODC#01";
            //string queryString = "Select * from Employee " + orderByClause + orderbydesc;
            //SqlConnection connection = new SqlConnection(connetionString);
            //SqlCommand command = new SqlCommand(queryString, connection);
            //connection.Open();

            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);

            //var aa = dt.AsEnumerable().Select(r => new Employee()
            //{
            //    EmployeeId = (int)r["EmployeeId"],
            //    FirstName = (string)r["FirstName"],
            //    LastName = (string)r["LastName"],
            //    EmployeeCode = (string)r["EmployeeCode"],
            //    Position = (string)r["Position"],
            //    Office = (string)r["Office"]
            //});

            var result = DataSourceLoader.Load(objdb.Employees, loadoptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);

        }
    }
}