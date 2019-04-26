using CaglarDurmus.ShoppingApi.Business.Abstract;
using CaglarDurmus.ShoppingApi.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaglarDurmus.ShoppingApi.MvcWebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),

                //QueryString'den categoryId alınır
                CurrentCategoryId = Convert.ToInt32(HttpContext.Request.Query["categoryId"])
            };

            return View(model);
        }
    }
}

