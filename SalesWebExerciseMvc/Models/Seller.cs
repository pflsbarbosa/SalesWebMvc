using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}€")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; } //EF see int as not null field in database
        public ICollection<SalesRecord> Sales { get; set; }

        public Seller() { }

        public Seller(string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            
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
