using FluentValidation;

namespace MovieStoreWebApi.App.CustomerOperations.Commands.UpdateCustomer{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator(){
            RuleFor(com => com.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(com => com.Model.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(com => com.Model.Surname).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(com => com.Model.Password).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(com => com.Model.Email).NotEmpty().NotNull().EmailAddress();
        }
    }
}