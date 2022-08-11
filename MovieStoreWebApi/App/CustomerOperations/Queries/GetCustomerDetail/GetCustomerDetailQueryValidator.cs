using FluentValidation;

namespace MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomerDetail{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty();
        }
    }
}