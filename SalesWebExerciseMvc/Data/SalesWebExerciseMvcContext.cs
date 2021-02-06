using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebExerciseMvc.Models;

namespace SalesWebExerciseMvc.Data
{
    public class SalesWebExerciseMvcContext : DbContext
    {
        public SalesWebExerciseMvcContext (DbContextOptions<SalesWebExerciseMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebExerciseMvc.Models.Department> Department { get; set; }
    }
}
