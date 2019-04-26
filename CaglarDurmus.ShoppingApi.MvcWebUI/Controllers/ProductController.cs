using CaglarDurmus.Northwind.Business.Abstract;
using CaglarDurmus.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaglarDurmus.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index(int page = 1, int categoryId = 0)
        {
            //Şimdilik Sabit
            int pageSize = 10;
            var products = _productService.GetByCategory(categoryId);

            ProductListViewModel model = new ProductListViewModel
            {
                //İlk page-1 kadar ürünü atla.Pagesize kadar ürünü al.
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategoryId = categoryId,
                CurrentPage = page
            };
            return View(model);
        }
    }
}

