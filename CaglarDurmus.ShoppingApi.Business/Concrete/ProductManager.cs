using CaglarDurmus.ShoppingApi.Business.Abstract;
using CaglarDurmus.ShoppingApi.DataAccess.Abstract;
using CaglarDurmus.ShoppingApi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaglarDurmus.ShoppingApi.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            //_productDal.Delete(this.GetById(productId));
            _productDal.Delete(new Product { ProductId = productId });
        }

        public Product GetById(int productId)
        {
            return _productDal.GetT(p => p.ProductId == productId);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId == 0);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
