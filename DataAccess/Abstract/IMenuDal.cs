﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IMenuDal : IGenericRepository<Menu>
    {
        Task<IEnumerable<MenuDto>> GetMenusByRestaurantIdAsync(Guid restaurantId);
        Task<IEnumerable<MenuDto>> GetAllWithDetailsAsync();
    }
}
