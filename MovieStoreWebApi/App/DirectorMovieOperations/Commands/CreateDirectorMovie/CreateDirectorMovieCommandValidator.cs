using FluentValidation;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Commands.CreateDirectorMovie{
    public class CreateDirectorMovieCommandValidator : AbstractValidator<CreateDirectorMovieCommand>{
        public CreateDirectorMovieCommandValidator(){
            RuleFor(comm => comm.model.DirectorId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.model.MovieId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}