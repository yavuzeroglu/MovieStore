using FluentValidation;

namespace MovieStoreWebApi.App.CustomerOperations.Commands.DeleteCustomer{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator(){
            RuleFor(com => com.id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}