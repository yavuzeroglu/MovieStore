using FluentValidation;

namespace MovieStoreWebApi.App.ActorOperations.Commands.DeleteActor{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator(){
            RuleFor(comm => comm.ActorId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}