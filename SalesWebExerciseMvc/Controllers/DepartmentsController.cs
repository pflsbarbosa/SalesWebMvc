using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebExerciseMvc.Models;


namespace SalesWebExerciseMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>();
            departments.Add(new Department { Id = 1, Name = "Administration" });
            departments.Add(new Department { Id = 2, Name = "Developing" });
            departments.Add(new Department { Id = 3, Name = "Sales" });
            departments.Add(new Department { Id = 4, Name = "Support" });
            departments.Add(new Department { Id = 5, Name = "Implementation" });

            return View(departments);
        }
    }
}
