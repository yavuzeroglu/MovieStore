using FluentValidation;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Queries.GetDetailDirectorMovie{
    public class GetDirectorMovieDetailValidator : AbstractValidator<GetDetailDirectorMovieQuery>
    {
        public GetDirectorMovieDetailValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}