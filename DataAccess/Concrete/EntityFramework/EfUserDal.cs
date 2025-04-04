﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfGenericRepository<User, SouthwindContext>, IUserDal
    {
        public async Task<UserDto> GetByEmailAsync(string email)
        {
            using var context = new SouthwindContext();
            var user = await context.Users
                .Where(u => u.Email == email)
                .Select(u => new UserDto
                {
                    Email = u.Email,
                    FullName = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    UserId = u.UserId
                })
                .SingleOrDefaultAsync();
            return user;
        }
    }
}
