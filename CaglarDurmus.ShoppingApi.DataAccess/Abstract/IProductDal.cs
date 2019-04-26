using CaglarDurmus.Core.DataAccess;
using CaglarDurmus.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaglarDurmus.Northwind.DataAccess.Abstract
{
    //Dal =  Data Access Layer
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
