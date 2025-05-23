﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.RestaurantId).NotEmpty();
            RuleFor(r => r.Rating).InclusiveBetween(1, 5).WithMessage(Messages.ReviewRatingRange);
        }
    }
}
