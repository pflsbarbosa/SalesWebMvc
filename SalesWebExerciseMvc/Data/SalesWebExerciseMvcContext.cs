using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebExerciseMvc.Models;
using SalesWebExerciseMvc.Models.Enums;

namespace SalesWebExerciseMvc.Data
{
    public class SalesWebExerciseMvcContext : DbContext
    {
        public SalesWebExerciseMvcContext (DbContextOptions<SalesWebExerciseMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> department { get; set; }
        public DbSet<Seller> seller { get; set; }
        public DbSet<SalesRecord> salesRecord { get; set; }
    }
}
