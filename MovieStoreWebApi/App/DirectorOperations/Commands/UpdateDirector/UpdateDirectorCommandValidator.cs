using FluentValidation;

namespace MovieStoreWebApi.App.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(comm => comm.Model.Surname).NotEmpty().NotNull().MinimumLength(3);
            
        }
    }
}