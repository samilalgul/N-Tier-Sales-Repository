using FluentValidation;
using Sales.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Validators
{
    public class CUDSaleValidator : AbstractValidator<CUDSaleDTO>
    {
        public CUDSaleValidator()
        {
            RuleFor(m => m.CustomerId)
                .NotEmpty()
                .WithMessage("'Customer Id' must not be 0.");
        }
    }
}
