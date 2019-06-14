using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevopsWithMvcApp.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace DevopsWithMvcApp.Controllers
{
    public class DevOpsController : Controller
    {
        SaurabhEntities objdata = new SaurabhEntities();
        DevOpsModel model = new DevOpsModel();

        // GET: DevOps
        [HttpGet]
        public ActionResult Index()
        {
            DevOpsModel objclass = new DevOpsModel();
            string PAT = "eq2qrld7f6nfw5ixwfe55vh2nsnycnalm32iyncf7gdlgi2nl6jq";
            List<object> lstItterationName = new List<object>();
            var TestDistinct = lstItterationName.Distinct();
            List<object> lstTitleName = new List<object>();
            var TestDistinctTitle = lstItterationName.Distinct();
            List<int> lstid = new List<int>();
            List<object> lstworker = new List<object>();
            var orderByWorker = lstworker.OrderBy(m => m);
            Dictionary<int, object> AuthorList2 = new Dictionary<int, object>();
            VssConnection connection = null;
            connection = new VssConnection(new Uri("https://" + "saurabhgupta0822" + ".visualstudio.com"), new VssBasicCredential(string.Empty, PAT));
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
            objclass.Workorder1 = orderByWorker.ToList();
            Session["DValues"] = AuthorList2;
            return View(objclass);
        }


        [HttpPost]
        public ActionResult Index(DevOpsModel objmodel)
        {
            TimeSheet objtable = new TimeSheet();
            if (ModelState.IsValid) { 
            //objtable.Name = objmodel.Name;
            objtable.HdName = objmodel.HdName;
            objtable.PBId =Convert.ToString(objmodel.Pbid);
            objtable.Sprint = Convert.ToString(objmodel.SprintName);
            objtable.Source = Convert.ToString(objmodel.Source);
            objtable.WorkorderType = Convert.ToInt16(objmodel.Workorder);
            objtable.SourceEmailDate = Convert.ToDateTime(objmodel.SourceEmailDate);
            objtable.TaskDate = Convert.ToDateTime(objmodel.TaskDate);
            objtable.Description = Convert.ToString(objmodel.Description);
            objtable.Hours = Convert.ToInt32(objmodel.Hours);
            objdata.TimeSheets.Add(objtable);
            objdata.SaveChanges();
                return Content("Data Saved Successfully!!!!");
            }
            return Content("Data Not Saved Successfully!!!!");
        }


        [HttpGet]
        public ActionResult title(int id)
        {
            Dictionary<int, object> AuthorList2 =  (Dictionary<int, object>)Session["DValues"];
            object value = "";
            if (AuthorList2.ContainsKey(id))
            {
                value = AuthorList2[id];
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}



