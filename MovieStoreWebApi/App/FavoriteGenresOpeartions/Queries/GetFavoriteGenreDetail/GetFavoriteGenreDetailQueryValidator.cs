using FluentValidation;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Queries.GetFavoriteGenreDetail{
    public class GetFavoriteGenreDetailQueryValidator : AbstractValidator<GetFavoriteGenreDetailQuery>{
        public GetFavoriteGenreDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}