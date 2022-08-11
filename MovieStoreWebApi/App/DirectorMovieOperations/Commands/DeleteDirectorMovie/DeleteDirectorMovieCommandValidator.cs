using FluentValidation;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Commands.DeleteDirectorMovie{
    public class DeleteDirectorMovieCommandValidator : AbstractValidator<DeleteDirectorMovieCommand>
    {
        public DeleteDirectorMovieCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}