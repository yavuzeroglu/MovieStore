using FluentValidation;

namespace MovieStoreWebApi.App.CustomerOperations.Commands.CreateCustomer{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator(){
            RuleFor(com => com.model.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(com => com.model.Surname).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(com => com.model.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(com => com.model.Password).NotEmpty().NotNull().MinimumLength(4);
        }
    }
}