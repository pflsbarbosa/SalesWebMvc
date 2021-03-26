using SalesWebExerciseMvc.Data;
using SalesWebExerciseMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Department>> FindAllAsync()
        {
            // "wait" is for the compiler to be informed that this is an asynchronous operation.
            return await _context.department.OrderBy(x => x.Name).ToListAsync();
        }


    }
}
