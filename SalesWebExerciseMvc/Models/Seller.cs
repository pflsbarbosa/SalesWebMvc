using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebExerciseMvc.Models;
using SalesWebExerciseMvc.Models.Enums;

namespace SalesWebExerciseMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; }

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
           return Sales.Where(x => x.Date >= initial && x.Date <= final && x.Status == SaleStatus.Billed).Sum(x => x.Amount); 
        }
    }
}
