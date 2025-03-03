﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfGenericRepository<Order>, IOrderDal
    {
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            var context = new SouthwindContext();
            var orders = await context.Orders.Where(o => o.UserId == userId).ToListAsync();
            return orders;
        }
    }
}
