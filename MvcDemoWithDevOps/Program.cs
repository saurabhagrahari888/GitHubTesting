using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace MvcDemoWithDevOps
{
    class Program
    {
        static void Main(string[] args)
        {         
            string PAT = "eq2qrld7f6nfw5ixwfe55vh2nsnycnalm32iyncf7gdlgi2nl6jq";

            List<object> lstItterationName = new List<object>();
            var TestDistinct = lstItterationName.Distinct();
            List<object> lstTitleName = new List<object>();
            var TestDistinctTitle = lstItterationName.Distinct();
            object tesTTitleNameAdd = "";
            List<object> lstTitleNameSprint = new List<object>();
            List<object> lstTitleNameSprintOther = new List<object>();

            VssConnection connection = null;
            // connection = new VssConnection(new Uri("https://" + account + ".visualstudio.com"), new VssBasicCredential(string.Empty, PAT)); saurabhgupta0822
            connection = new VssConnection(new Uri("https://" + "saurabhgupta0822" + ".visualstudio.com"), new VssBasicCredential(string.Empty, PAT));
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
            Wiql wiql = new Wiql();
            //wiql.Query = "SELECT System.Title from workitems where System.ID = 1";
            wiql.Query = "SELECT System.Title from workitems";
            WorkItemQueryResult tasks = witClient.QueryByWiqlAsync(wiql).Result;
            IEnumerable<WorkItemReference> tasksRefs;
            tasksRefs = tasks.WorkItems;
            List<WorkItem> tasksList = witClient.GetWorkItemsAsync(tasksRefs.Select(wir => wir.Id)).Result;
            foreach (var item in tasksList)
            {
                var ItterationNameAdd = item.Fields["System.IterationPath"];
                lstItterationName.Add(ItterationNameAdd);
                 tesTTitleNameAdd = item.Fields["System.Title"];
                var testdata = item.Fields["System.IterationPath"].ToString().Contains(ItterationNameAdd.ToString());


               
              //  var data = fetchSprintData(ItterationNameAdd);
                

                //   wiql.Query = "SELECT System.Title from workitems where System.IterationPath = " + ItterationNameAdd;
                //   WorkItemQueryResult tasks1 = witClient.QueryByWiqlAsync(wiql).Result;
                //   IEnumerable<WorkItemReference> tasksRefs1;
                //   tasksRefs1 = tasks.WorkItems;
                //   List<WorkItem> tasksList1 = witClient.GetWorkItemsAsync(tasksRefs.Select(wir => wir.Id)).Result;

            }
            foreach (var item1 in tasksList)
            {
                object tesTTitleNameAdd1 = "";
                var a = item1.Id;
                var ItterationNameAdd1 = item1.Fields["System.IterationPath"];        
                var testdata = item1.Fields["System.IterationPath"].ToString().Contains(ItterationNameAdd1.ToString());
                if(testdata == true) { 
                foreach (var item11 in lstItterationName)
                {
                  if(item11.ToString() == ItterationNameAdd1.ToString())
                        {
                            tesTTitleNameAdd1 = item1.Fields["System.Title"];
                            lstTitleNameSprint.Add(tesTTitleNameAdd1.ToString());
                        }
                        else
                        {
                            lstTitleNameSprintOther.Add(tesTTitleNameAdd1.ToString());
                        }
                }
                }
            }


            foreach (var Title in tasksList)
            {
                tesTTitleNameAdd = Title.Fields["System.Title"];
                lstTitleName.Add(tesTTitleNameAdd);
            }


            var tesTTitleName = tasksList[0].Fields["Microsoft.VSTS.Common.BusinessValue"];
            //lstItterationName.ForEach(Console.WriteLine);
        TestDistinct.ForEach(Console.WriteLine);
            Console.ReadKey();
            Console.ReadKey();


            //object fetchSprintData(object sprintName)
            //{
            //    string b = sprintName.ToString();
            //  var a = b.Split('\\').Last();


            //    ///Have to Fetch All The Data from Taking Inside List..



               








            //   // wiql.Query = "SELECT System.ID System.Title from workitems where System.IterationPath = " + a;
            //   // WorkItemQueryResult tasksNew = witClient.QueryByWiqlAsync(wiql).Result;
            //  //  IEnumerable<WorkItemReference> tasksRefsNew;
            //  //  tasksRefsNew = tasks.WorkItems;
            //  //  List<WorkItem> tasksListNew = witClient.GetWorkItemsAsync(tasksRefs.Select(wir => wir.Id)).Result;


            //    VssConnection connection1 = null;
            //    // connection = new VssConnection(new Uri("https://" + account + ".visualstudio.com"), new VssBasicCredential(string.Empty, PAT)); saurabhgupta0822
            //    connection1 = new VssConnection(new Uri("https://" + "saurabhgupta0822" + ".visualstudio.com"), new VssBasicCredential(string.Empty, PAT));
            //    WorkItemTrackingHttpClient witClient1 = connection.GetClient<WorkItemTrackingHttpClient>();
            //    Wiql wiql1 = new Wiql();
            //   //  wiql1.Query = "SELECT *  from workitems";
            //    wiql1.Query = @"SELECT * from workitems where [System.IterationPath] = 'MVCDemo\Sprint1'";
            //    WorkItemQueryResult tasks1 = witClient1.QueryByWiqlAsync(wiql1).Result;
            //    IEnumerable<WorkItemReference> tasksRefs1;
            //    tasksRefs1 = tasks1.WorkItems;
            //    List<WorkItem> tasksList1 = witClient1.GetWorkItemsAsync(tasksRefs.Select(wir => wir.Id)).Result;


            //    return tasksList1;
            //}
        }     
        
    }
}
