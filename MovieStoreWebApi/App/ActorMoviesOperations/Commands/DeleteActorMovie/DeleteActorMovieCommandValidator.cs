using FluentValidation;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Commands.DeleteActorMovie{
    public class DeleteActorMovieCommandValidator : AbstractValidator<DeleteActorMovieCommand>
    {
        public DeleteActorMovieCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}