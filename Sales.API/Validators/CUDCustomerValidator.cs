using FluentValidation;
using Sales.API.DTOs;

namespace Sales.API.Validators
{
    public class CUDCustomerValidator : AbstractValidator<CUDCustomerDTO>
    {
        public CUDCustomerValidator()
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .MaximumLength(50);
        }
    }
}
