using FluentValidation;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Commands.DeleteFavoriteGenre{
    public class DeleteFavoriteGenreCommandValidator : AbstractValidator<DeleteFavoriteGenreCommand>{
        public DeleteFavoriteGenreCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}