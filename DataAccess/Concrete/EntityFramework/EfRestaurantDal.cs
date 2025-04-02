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
    public class EfRestaurantDal : EfGenericRepository<Restaurant, SouthwindContext>, IRestaurantDal
    {
        public async Task<IEnumerable<Restaurant>> GetByOwnerIdAsync(Guid ownerId)
        {
            using var context = new SouthwindContext();
            var restaurants = await context.Restaurants.Where(r => r.OwnerId == ownerId).ToListAsync();
            return restaurants;
        }
    }
}
