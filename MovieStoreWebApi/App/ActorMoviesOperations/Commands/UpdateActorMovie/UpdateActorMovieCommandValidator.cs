using FluentValidation;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Commands.UpdateActorMovie{
    public class UpdateActorMovieCommandValidator : AbstractValidator<UpdateActorMovieCommand>
    {
        public UpdateActorMovieCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(comm => comm.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(comm => comm.model.ActorId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}