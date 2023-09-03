using FluentValidation;
using Mc2.CrudTest.Presentation.Core.DefineAttributes;
using Mc2.CrudTest.Presentation.Core.Entities;

namespace Mc2.CrudTest.Presentation.Core.Validators
{    
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(100).NotNull().NotEmpty().WithMessage("Please specify a first name");
            RuleFor(x => x.LastName).MaximumLength(150).NotNull().NotEmpty().WithMessage("Please specify a last name");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address")
                .MaximumLength(50).NotNull().NotEmpty().WithMessage("Please specify an email address");
            RuleFor(x => x.BankAccountNumber).MaximumLength(25)
                .Matches(@"^[0-9]{9,18}$").WithMessage("Invalid Bank Account Number.");
            RuleFor(x => x.PhoneNumber)
                .Must(new PhoneNumberAttribute().IsValid).WithMessage("Please ensure that to set a valid value for {PropertyName}")
                .MaximumLength(20);
        }
    }
}
