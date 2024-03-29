﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.CardCvv).NotEmpty();
            RuleFor(p => p.CardExpiryDate).NotEmpty();
            RuleFor(p => p.CardNumber).NotEmpty();
        }

    }
}
