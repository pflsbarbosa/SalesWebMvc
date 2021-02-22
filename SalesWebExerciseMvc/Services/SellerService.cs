using SalesWebExerciseMvc.Data;
using SalesWebExerciseMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebExerciseMvc.Services.Exceptions;

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

        public List<Seller> FindingAll()
        {

            return _context.seller.ToList();//Syncronous function

        }
        public void Insert(Seller obj)
        {

            //insert the obj in the database
            _context.Add(obj);
            //Granting or confirming the changes
            _context.SaveChanges();

        }
        public Seller FindById(int id)
        {
            //Eager Loaad(load other objects associated with the main object)
            //Insert Include form Microsoft Enitiy Frame Work Core to Make a "Join"
            return _context.seller.Include(obj => obj.Department).FirstOrDefault(seller => seller.Id == id);
        }

        public void Remove(int id)
        {
            var sellerToDelete = _context.seller.Find(id);
            _context.seller.Remove(sellerToDelete);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.seller.Any(s => s.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try //using try to avoid DB concurrency exception
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
