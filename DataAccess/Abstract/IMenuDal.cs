﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMenuDal : IGenericRepository<Menu>
    {
        Task<IEnumerable<Menu>> GetMenusByRestaurantIdAsync(Guid restaurantId);
    }
}
