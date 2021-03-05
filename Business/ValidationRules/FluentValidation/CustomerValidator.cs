using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        //https://docs.fluentvalidation.net/en/latest/ docu
        public CustomerValidator()
        {
            RuleFor(cus => cus.UserId).NotEmpty();
            RuleFor(cus => cus.CompanyName).NotEmpty();
            RuleFor(cus => cus.CompanyName).MinimumLength(2);
        }
    }
}
