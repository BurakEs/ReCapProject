using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {

        //https://docs.fluentvalidation.net/en/latest/ docu
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            //Dailyprice 10 dan büyük veya eşit olmadı Brand Id si 2 olanlar için.
            //RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.BrandId == 2);
        }

    }
}
