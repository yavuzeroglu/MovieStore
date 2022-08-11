using FluentValidation;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.CreatePurchasedMovies{
    public class CreatePurchasedMoviesCommandValidator : AbstractValidator<CreatePurchasedMoviesCommand>
    {
        public CreatePurchasedMoviesCommandValidator(){
            RuleFor(comm => comm.model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(comm => comm.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
            
        }
    }
}