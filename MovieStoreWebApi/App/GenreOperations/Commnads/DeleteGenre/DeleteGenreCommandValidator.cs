using FluentValidation;

namespace MovieStoreWebApi.App.GenreOperations.Commands.DeleteGenre{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>{
        public DeleteGenreCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotNull().NotEmpty();
            
        }
    }
}