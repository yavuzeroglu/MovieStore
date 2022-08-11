using FluentValidation;

namespace MovieStoreWebApi.App.DirectorOperations.Commands.CreateDirector{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>{
        public CreateDirectorCommandValidator(){
            RuleFor(comm => comm.Model.Name).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.Surname).MinimumLength(3).NotEmpty().NotNull();
        }
    }
}