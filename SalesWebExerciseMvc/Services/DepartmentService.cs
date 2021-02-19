using SalesWebExerciseMvc.Data;
using SalesWebExerciseMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebExerciseMvc.Services
{
    public class DepartmentService
    {
        //+++ Dependency injection +++
        //Declaration
        private readonly SalesWebExerciseMvcContext _context;
        //constructor
        public DepartmentService(SalesWebExerciseMvcContext context)
        {
            _context = context;
        }
        //--- End of Dependency injection ---

        //implementing methods
        public List<Department> FindAll()
        {
            return _context.department.OrderBy(x => x.Name).ToList();
        }


    }
}
