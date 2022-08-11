using FluentValidation;

namespace MovieStoreWebApi.App.ActorOperations.Commands.UpdateActor{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator(){
            RuleFor(comm => comm.ActorId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.Name).MinimumLength(2).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.Surname).MinimumLength(2).NotEmpty().NotNull();
        }
    }
}