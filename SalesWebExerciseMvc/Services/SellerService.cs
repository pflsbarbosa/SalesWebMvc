using SalesWebExerciseMvc.Data;
using SalesWebExerciseMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebExerciseMvc.Services
{
    public class SellerService
    {
        //+++ Dependency injection +++
        private readonly SalesWebExerciseMvcContext _context;

        public SellerService(SalesWebExerciseMvcContext context)
        {
            _context = context;
        }

        //--- End of Dependency injection ---


        // implementig find all        

        public List<Seller> FindingAll () {

            return _context.seller.ToList();//Syncronous function
                      
        }

        public void Insert(Seller obj)
        {
            
            //insert the obj in the database
            _context.Add(obj);
            //Granting or confirming the changes
            _context.SaveChanges();
            
        }


    }
}
