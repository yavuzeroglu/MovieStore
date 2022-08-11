using FluentValidation;

namespace MovieStoreWebApi.App.DirectorOperations.Commands.DeleteDirector{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}