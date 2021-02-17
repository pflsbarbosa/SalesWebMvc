using Microsoft.AspNetCore.Mvc;
using SalesWebExerciseMvc.Models;
using SalesWebExerciseMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebExerciseMvc.Controllers
{
    public class SellersController : Controller
    {
        //Declaring seller service dependency
        private readonly SellerService _sellerService ;
        // constructor for injection dependency
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindingAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
