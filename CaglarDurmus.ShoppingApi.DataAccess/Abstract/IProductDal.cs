using CaglarDurmus.Core.DataAccess;
using CaglarDurmus.ShoppingApi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaglarDurmus.ShoppingApi.DataAccess.Abstract
{
    //Dal =  Data Access Layer
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
