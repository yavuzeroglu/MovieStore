using FluentValidation;

namespace MovieStoreWebApi.App.MovieOperations.Commands.CreateMovie{

    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>{
        public CreateMovieCommandValidator(){
            RuleFor(comm => comm.Model.GenreId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(comm => comm.Model.Price).GreaterThan(5).NotNull().NotEmpty();
            RuleFor(comm => comm.Model.Title).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(comm => comm.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.AddDays(1));
        }
    }
}