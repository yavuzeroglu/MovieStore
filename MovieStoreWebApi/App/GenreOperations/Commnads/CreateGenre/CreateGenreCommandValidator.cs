using FluentValidation;

namespace MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>{
        public CreateGenreCommandValidator(){
            RuleFor(comm => comm.Model.Name).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}