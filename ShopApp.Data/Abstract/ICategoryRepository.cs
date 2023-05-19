﻿using ShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetAllUndeletedCategories();
    }
}
