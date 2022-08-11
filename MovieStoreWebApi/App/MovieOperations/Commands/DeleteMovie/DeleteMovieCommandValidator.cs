using FluentValidation;

namespace MovieStoreWebApi.App.MovieOperations.Commands.DeleteMovie{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>{
        public DeleteMovieCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}