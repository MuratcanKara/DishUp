﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Business.Helpers;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MenuItemValidator : AbstractValidator<MenuItem>
    {
        public MenuItemValidator()
        {
            RuleFor(mi => mi.MenuId).NotEmpty();
            RuleFor(mi => mi.Name).MaximumLength(100).WithMessage(Messages.MenuItemNameRequired);
            RuleFor(mi => mi.Description).MaximumLength(500);
            RuleFor(mi => mi.ImageUrl).MaximumLength(200);
            RuleFor(mi => mi.Price).GreaterThan(0).WithMessage(Messages.MenuItemPricePositive).Must(value => ValidationHelpers
                .HasValidDecimalPrecision(value, 18, 2)).WithMessage(Messages.MenuItemPricePrecision);
        }
    }
}
