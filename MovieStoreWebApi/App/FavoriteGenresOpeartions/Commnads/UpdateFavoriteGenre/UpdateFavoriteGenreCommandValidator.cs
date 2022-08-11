using FluentValidation;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Commands.UpdateFavoriteGenre{
    public class UpdateFavoriteGenreCommandValidator : AbstractValidator<UpdateFavoriteGenreCommand>{
        public UpdateFavoriteGenreCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.FavoriteGenreId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}