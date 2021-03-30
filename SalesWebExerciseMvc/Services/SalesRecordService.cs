﻿using Microsoft.EntityFrameworkCore;
using SalesWebExerciseMvc.Data;
using SalesWebExerciseMvc.Models;
using SalesWebExerciseMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebExerciseMvc.Services
{
    public class SalesRecordService
    {
        //+++ Dependency injection +++
        private readonly SalesWebExerciseMvcContext _context;

        public SalesRecordService(SalesWebExerciseMvcContext context)
        {
            _context = context;
        }
        //--- End of Dependency injection ---

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            // return await _context.salesRecord.Where(dt => (dt.Date >= min.Value)&&((dt.Date < max.Value))).ToListAsync();
            var result = from obj in _context.salesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller) // join table Seller
                .Include(x => x.Seller.Department)// join table Departments
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

       

      
    }
}
