using FluentValidation;

namespace MovieStoreWebApi.App.GenreOperations.Queries.GetGenreDetail{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }   
    }
}