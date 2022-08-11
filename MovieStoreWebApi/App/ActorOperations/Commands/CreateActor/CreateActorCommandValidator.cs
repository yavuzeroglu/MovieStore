using FluentValidation;

namespace MovieStoreWebApi.App.ActorOperations.Commands.CreateActor{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator(){
            RuleFor(comm => comm.Model.Name).MinimumLength(2).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.Surname).MinimumLength(2).NotEmpty().NotNull();
            

        }
    }
}