﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMenuDal : EfGenericRepository<Menu, SouthwindContext>, IMenuDal
    {
        public async Task<IEnumerable<Menu>> GetMenusByRestaurantIdAsync(Guid restaurantId)
        {
            using var context = new SouthwindContext();
            var menus = await context.Menus.Where(m => m.RestaurantId == restaurantId).ToListAsync();
            return menus;
        }
    }
}
