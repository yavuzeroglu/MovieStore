using FluentValidation;

namespace MovieStoreWebApi.App.MovieOperations.Commands.UpdateMovie{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>{
        public UpdateMovieCommandValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.GenreId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.Price).GreaterThan(5).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.PublishDate).LessThan(DateTime.Now.AddDays(1));
            RuleFor(comm => comm.Model.Title).MinimumLength(2).NotEmpty().NotNull();
        }
    }
}