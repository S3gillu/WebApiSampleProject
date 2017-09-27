using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiSampleProject.Models;

namespace WebApiSampleProject.Controllers
{
    public class ContextClass :DbContext
    {
      
        public ContextClass()
                : base("Context")
        {
        }
        public DbSet<EmployeeAgain> EmployeeAgains { get; set; }
     
    }
}