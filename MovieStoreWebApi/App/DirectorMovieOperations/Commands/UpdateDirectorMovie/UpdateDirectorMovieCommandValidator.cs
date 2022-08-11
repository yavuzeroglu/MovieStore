using FluentValidation;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Commands.UpdateDirectorMovie{
    public class UpdateDirectorMovieCommandValidator : AbstractValidator<UpdateDirectorMovieCommand>
    {
        public UpdateDirectorMovieCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.DirectorId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}