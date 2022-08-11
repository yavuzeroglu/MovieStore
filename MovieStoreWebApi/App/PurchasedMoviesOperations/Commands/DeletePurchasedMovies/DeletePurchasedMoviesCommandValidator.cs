using FluentValidation;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.DeletePurchasedMovies{
    public class DeletePurchasedMoviesCommandValidator : AbstractValidator<DeletePurchasedMoviesCommand>{
        public DeletePurchasedMoviesCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}