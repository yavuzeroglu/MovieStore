using FluentValidation;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Commands.CreateActorMovie{
    public class CreateActorMovieCommandValidator : AbstractValidator<CreateActorMovieCommand>
    {
        public CreateActorMovieCommandValidator(){
            RuleFor(command => command.model.ActorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}