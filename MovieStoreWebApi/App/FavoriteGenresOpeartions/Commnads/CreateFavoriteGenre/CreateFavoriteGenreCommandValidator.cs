using FluentValidation;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Commands.CreateFavoriteGenre{
    public class CreateFavoriteGenreCommandValidator : AbstractValidator<CreateFavoriteGenreCommand>
    {
        public CreateFavoriteGenreCommandValidator(){
            RuleFor(comm => comm.model.CustomerId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.model.FavoriteGenreId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}