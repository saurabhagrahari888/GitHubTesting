using System.Web.Mvc;

namespace ListPassing.Areas.TestAreaName
{
    public class TestAreaNameAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TestAreaName";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TestAreaName_default",
                "TestAreaName/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}