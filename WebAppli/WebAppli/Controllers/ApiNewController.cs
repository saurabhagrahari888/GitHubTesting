using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppli.Controllers
{
    public class ApiNewController : ApiController
    {
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public DateTime JoiningDate { get; set; }
            public int Age { get; set; }
        }

        Employee[] employees = new Employee[]{
         new Employee { ID = 1, Name = "Mark", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
         new Employee { ID = 2, Name = "Allan", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
         new Employee { ID = 3, Name = "Johny", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 21 }
      };
        //public IEnumerable<Employee> GetAllEmployees()
        //{
        //    return employees;
        //}
        public IHttpActionResult GetAllEmployees()
        {
            string url = "http://localhost:58857/Home/about";

            return Redirect(url);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault((p) => p.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


    }
}
