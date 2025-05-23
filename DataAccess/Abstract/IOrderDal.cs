﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IOrderDal : IGenericRepository<Order>
{
    Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(Guid userId);
    Task<IEnumerable<OrderDto>> GetOrdersByRestaurantIdAsync(Guid restaurantId);
    Task<IEnumerable<OrderDto>> GetAllWithDetailsAsync();
}