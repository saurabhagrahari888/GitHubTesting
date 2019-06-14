
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevExpressProj.Models;

namespace DevExpressProj.Controllers
{
    public class TestDataController : ApiController
    {
        SaurabhEntities objdb = new SaurabhEntities();
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            var data = objdb.Employees.Select(t => t).ToList();
            // return new string[] { "value1", "value2" };
            return data;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}