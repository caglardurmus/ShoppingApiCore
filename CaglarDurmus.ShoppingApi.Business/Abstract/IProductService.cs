using CaglarDurmus.ShoppingApi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaglarDurmus.ShoppingApi.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int productId);
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
