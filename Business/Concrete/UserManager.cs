﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<User>> GetByIdAsync(Guid id)
        {
            var user = await _userDal.GetByIdAsync(id);
            // null mi
            return new SuccessDataResult<User>(user);
        }

        [LogAspect]
        public async Task<IDataResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            var users = await _userDal.GetAllWithDetailsAsync();
            // null mi
            return new SuccessDataResult<IEnumerable<UserDto>>(users);
        }

        public async Task<IDataResult<IEnumerable<User>>> GetByConditionAsync(Expression<Func<User, bool>> predicate)
        {
            var users = await _userDal.GetByConditionAsync(predicate);
            // null mi
            return new SuccessDataResult<IEnumerable<User>>(users);
        }

        public async Task<IResult> AddAsync(User entity)
        {
            await _userDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(User entity)
        {
            var existingUser = await _userDal.GetByIdAsync(entity.UserId);
            if (existingUser == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            existingUser.Email = entity.Email;
            existingUser.FullName = entity.FullName;
            existingUser.PhoneNumber = entity.PhoneNumber;
            existingUser.Role = entity.Role;
            await _userDal.UpdateAsync(existingUser);
            return new SuccessResult(Messages.UserUpdated);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var userToDelete = await _userDal.GetByIdAsync(id);
            // null mi
            await _userDal.DeleteAsync(userToDelete.UserId);
            return new SuccessResult();
        }

        public async Task<IDataResult<UserDto>> GetByEmailAsync(string email)
        {
            var user = await _userDal.GetByEmailAsync(email);
            // null mi
            return new SuccessDataResult<UserDto>(user);
        }
        }
    }

