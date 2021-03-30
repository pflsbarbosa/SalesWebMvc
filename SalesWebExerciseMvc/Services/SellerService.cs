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

        public async Task<List<Seller>> FindingAllAsync()
        {
            return await _context.seller.ToListAsync();//Asyncronous function
        }
        public async Task InsertAsync(Seller obj)
        {

            //insert the obj in the database
            _context.Add(obj);
            //Granting or confirming the changes
            await _context.SaveChangesAsync();

        }
        public async Task<Seller> FindByIdAsync(int id)
        {
            //Eager Loaad(load other objects associated with the main object)
            //Insert Include form Microsoft Enitiy Frame Work Core to Make a "Join"
            return await _context.seller.Include(obj => obj.Department).FirstOrDefaultAsync(seller => seller.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var sellerToDelete = await _context.seller.FindAsync(id);
                _context.seller.Remove(sellerToDelete);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller obj)
        {

            bool hasAny = await _context.seller.AnyAsync(s => s.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try //using try to avoid DB concurrency exception
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
