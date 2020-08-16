using FluentValidation;
using Sales.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Validators
{
    public class CUDProductDTOValidator : AbstractValidator<CUDProductDTO>
    {
        public CUDProductDTOValidator()
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .MaximumLength(50);
        }
    }
}
