using FluentValidation;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Queries.GetPurchasedMoviesDetail{
    public class GetPurchasedMoviesDetailQueryValidator : AbstractValidator<GetPurchasedMoviesDetailQuery>
    {
        public GetPurchasedMoviesDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}