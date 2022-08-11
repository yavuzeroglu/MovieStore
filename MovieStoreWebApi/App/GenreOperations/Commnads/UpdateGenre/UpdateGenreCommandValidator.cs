using FluentValidation;

namespace MovieStoreWebApi.App.GenreOperations.Commands.UpdateGenre{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>{
        public UpdateGenreCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(comm => comm.Model.Name).MinimumLength(2).NotEmpty().NotNull();
        }
    }
}