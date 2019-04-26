using CaglarDurmus.Core.EntityFramework;
using CaglarDurmus.Northwind.DataAccess.Abstract;
using CaglarDurmus.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaglarDurmus.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
