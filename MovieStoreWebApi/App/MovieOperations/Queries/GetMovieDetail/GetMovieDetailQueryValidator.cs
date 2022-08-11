using FluentValidation;

namespace MovieStoreWebApi.App.MovieOperations.Queries.GetMovieDetail{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>{
        public GetMovieDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}