using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using TestCrud.Models;

namespace TestCrud.Controllers
{
    public class TimesheetController : Controller
    {
        SaurabhEntities objdata = new SaurabhEntities();
        public ActionResult Index()
        {      
            
            return View();
        }
        [HttpGet]
        public ActionResult FetchId(string id)
        {
            Session["EmpId"] = id;         
            return Content("Inserted Employeeid!!");
        }
        public ActionResult GetData(DataSourceLoadOptions loadOptions)
        {
          
            var result = DataSourceLoader.Load(objdata.TimeSheets, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);

        }
       [HttpPost]
        public ActionResult PostData(string values)
        {
            var employeeId = Session["EmpId"];
            TimeSheet objtable = new TimeSheet();
            objtable.Name = employeeId.ToString();
            JsonConvert.PopulateObject(values, objtable);
            objdata.TimeSheets.Add(objtable);
            objdata.SaveChanges();
            return Content("Data Saved Succesfully!!!!");
        }

        [HttpPut]
        public ActionResult EditData(int key, string values)
        {
            var EditedData = objdata.TimeSheets.First(o => o.ID == key); 
            JsonConvert.PopulateObject(values, EditedData);  
            objdata.SaveChanges();
            return Content("Data Updated Succesfully!!!!");
        }
        [HttpDelete]
        public ActionResult DeleteData(int key)
        {
            var Deletedata = objdata.TimeSheets.First(o => o.ID == key); 
            objdata.TimeSheets.Remove(Deletedata);          
            objdata.SaveChanges();
            return Content("Data Saved Succesfully!!!!");
        }
        [HttpGet]
        public ActionResult Timesheetdropdowns(DataSourceLoadOptions loadOptions)
        {           
            DevOps objclass = MainMethod();
            var dropdowndata = from i in objclass.SprintName1
                               select new
                               {
                                   Value = i,
                                   Text = i
                               };
            var result = DataSourceLoader.Load(dropdowndata, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);
        }
        public ActionResult TimesheetdropdownsPBID(DataSourceLoadOptions loadOptions)
        {
            DevOps objclass = MainMethod();
            var dropdowndata = from i in objclass.Pbid1
                               select new
                               {
                                   Value = i,
                                   Text = i
                               };
            var result = DataSourceLoader.Load(dropdowndata, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);
        }

        public ActionResult TimesheetdropdownsWorkOrder(DataSourceLoadOptions loadOptions)
        {
            DevOps objclass = MainMethod();
            var dropdowndata = from i in objclass.Workorder1
                               select new
                               {
                                   Value = i,
                                   Text = i
                               };
            var result = DataSourceLoader.Load(dropdowndata, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);
        }
        public ActionResult TimesheetDropdownSource(DataSourceLoadOptions loadOptions)
        {
            DevOps objclass = MainMethod();
            var dropdowndata = from i in objclass.Source
                               select new
                               {
                                   Value = i.Value,
                                   Text = i.Text
                               };
            var result = DataSourceLoader.Load(dropdowndata, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);
        }

        public ActionResult GetItems(DataSourceLoadOptions loadOptions)
        {
            TimeSheetTrackerEntities objtimesheet = new TimeSheetTrackerEntities();
            var NameData = objtimesheet.EmployeeMasters.Select(t => t).ToList();
            var dropdowndata = from i in NameData
                               select new
                               {
                                   Value = i.EmployeeCode,
                                   Text = i.EmployeeName
                               };
            var result = DataSourceLoader.Load(dropdowndata, loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson);
        }
        [HttpGet]
        public ActionResult title(int id)
        {
            Dictionary<int, object> AuthorList2 = (Dictionary<int, object>)Session["DValues"];
            object value = "";
            if (AuthorList2.ContainsKey(id))
            {
                value = AuthorList2[id];  
            }
            Session["Title"] = value;
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public DevOps MainMethod()
        {
            DevOps objclass = new DevOps();
            string PAT = System.Configuration.ConfigurationManager.AppSettings["Pat"];
            string UrlDevops = System.Configuration.ConfigurationManager.AppSettings["UrlDevops"];

           // string PAT = "eq2qrld7f6nfw5ixwfe55vh2nsnycnalm32iyncf7gdlgi2nl6jq";
            List<object> lstItterationName = new List<object>();
            var TestDistinct = lstItterationName.Distinct();
            List<object> lstTitleName = new List<object>();
            var TestDistinctTitle = lstItterationName.Distinct();
            List<int> lstid = new List<int>();
            List<object> lstworker = new List<object>();
            var orderByWorker = lstworker.OrderBy(m => m);
            Dictionary<int, object> AuthorList2 = new Dictionary<int, object>();
            VssConnection connection = null;
            connection = new VssConnection(new Uri(UrlDevops), new VssBasicCredential(string.Empty, PAT));//To Call From Web Config.
            //  connection = new VssConnection(new Uri("https://" + "saurabhgupta0822" + ".visualstudio.com"), new VssBasicCredential(string.Empty, PAT));
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
            Wiql wiql = new Wiql();
            wiql.Query = "SELECT System.Title from workitems";
            WorkItemQueryResult tasks = witClient.QueryByWiqlAsync(wiql).Result;
            IEnumerable<WorkItemReference> tasksRefs;
            tasksRefs = tasks.WorkItems;
            List<WorkItem> tasksList = witClient.GetWorkItemsAsync(tasksRefs.Select(wir => wir.Id)).Result;
            foreach (var item in tasksList)
            {
                var ItterationNameAdd = item.Fields["System.IterationPath"];
                lstItterationName.Add(ItterationNameAdd);
                var tesTTitleNameAdd = item.Fields["System.Title"];
                lstTitleName.Add(tesTTitleNameAdd);
                var itemid = (int)item.Id;
                lstid.Add(itemid);
                var worker = item.Fields["Microsoft.VSTS.Common.BusinessValue"];
                lstworker.Add(worker);
                AuthorList2.Add(itemid, tesTTitleNameAdd);
            }
            objclass.SprintName1 = TestDistinct.ToList();
            var a = DateTime.Now.ToString("MM/dd/yyyy");
            objclass.TaskDate = a;
            objclass.SourceEmailDate = a;
            objclass.Pbid1 = lstid;
            objclass.Workorder1 = Convert.ToString(Session["Title"]);
            //objclass.Workorder1 = orderByWorker.ToList();
            Session["DValues"] = AuthorList2;
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "DevOps",
                Value = "1"
            });
            items.Add(new SelectListItem
            {
                Text = "Email",
                Value = "2"
            });
            items.Add(new SelectListItem
            {
                Text = "Incident",
                Value = "3"
            });
            items.Add(new SelectListItem
            {
                Text = "Others",
                Value = "4"
            });
            objclass.Source = items;
            Session["DevOpsAllData"] = objclass;
            return objclass;
        }

    }
}