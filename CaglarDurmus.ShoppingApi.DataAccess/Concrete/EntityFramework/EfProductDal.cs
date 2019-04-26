using CaglarDurmus.Core.EntityFramework;
using CaglarDurmus.ShoppingApi.DataAccess.Abstract;
using CaglarDurmus.ShoppingApi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaglarDurmus.ShoppingApi.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ShoppingApiContext>, IProductDal
    {
    }
}
