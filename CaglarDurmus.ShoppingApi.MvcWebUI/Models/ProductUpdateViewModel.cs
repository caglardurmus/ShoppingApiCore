using System.Collections.Generic;
using CaglarDurmus.ShoppingApi.Entities.Concrete;

namespace CaglarDurmus.ShoppingApi.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}