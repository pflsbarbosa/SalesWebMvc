using Microsoft.AspNetCore.Mvc;
using SalesWebExerciseMvc.Models;
using SalesWebExerciseMvc.Models.ViewModels;
using SalesWebExerciseMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebExerciseMvc.Controllers
{
    public class SellersController : Controller
    {
        //Declaring services dependency
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        // constructor for injection dependency
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }



        public IActionResult Index()
        {
            var list = _sellerService.FindingAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
                        
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
