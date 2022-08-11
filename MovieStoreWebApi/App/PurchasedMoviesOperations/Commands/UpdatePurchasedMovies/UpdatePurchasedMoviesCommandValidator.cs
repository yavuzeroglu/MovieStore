using FluentValidation;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.UpdatePurchasedMovies{
    public class UpdatePurchasedMoviesCommandValidator : AbstractValidator<UpdatePurchasedMoviesCommand>{
        public UpdatePurchasedMoviesCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.model.CustomerId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.model.MovieId).GreaterThan(0).NotEmpty().NotNull();
            
        }
    }
}