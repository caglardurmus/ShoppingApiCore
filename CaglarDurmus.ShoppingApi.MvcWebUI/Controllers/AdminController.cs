using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaglarDurmus.ShoppingApi.Business.Abstract;
using CaglarDurmus.ShoppingApi.Entities.Concrete;
using CaglarDurmus.ShoppingApi.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaglarDurmus.ShoppingApi.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {

        private IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(productListViewModel);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added");
            }
            return RedirectToAction("Index");
        }
    }
}