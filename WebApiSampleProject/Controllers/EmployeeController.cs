using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiSampleProject.Models;

namespace WebApiSampleProject.Controllers
{
    public class EmployeeController : ApiController
    {
        ContextClass db = new ContextClass();
        IList<EmployeeAgain> employees = new List<EmployeeAgain>()
        {
            new EmployeeAgain()
            {
                EmployeeAgainId=1,EmployeeAgainName="Shubham Saurabh", Address="Patna",Department="MS"

            },
            new EmployeeAgain()
            {
                EmployeeAgainId=2,EmployeeAgainName="Mayank Joshi",Address="haldwani", Department="Mean",
            },
            new EmployeeAgain()
            { EmployeeAgainId=3, EmployeeAgainName ="Aniket Kadu", Address="Nagpur",Department="React",},

        };
        public IList<EmployeeAgain> GetAllEmployees()
        {
            return employees;
        }
        public EmployeeAgain GetEmployeeDetails(int id)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeAgainId == id);
            if (employee==null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }
        // POST: api/Products
        [ResponseType(typeof(EmployeeAgain))]
        public IHttpActionResult PostProduct(EmployeeAgain shubham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeAgains.Add(shubham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shubham.EmployeeAgainId }, shubham);
        }
        [HttpDelete]
                     public void DeleteEmployeedetail(int id)
        {
            var x = db.EmployeeAgains.SingleOrDefault(c => c.EmployeeAgainId == id);
            if (x == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.EmployeeAgains.Remove(x);
            db.SaveChanges();



        }

    }
}
