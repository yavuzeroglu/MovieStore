using FluentValidation;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Queries.GetActorMovieDetail{
    public class GetActorMovieDetailQueryValidator : AbstractValidator<GetActorMovieDetailQuery>
    {
        public GetActorMovieDetailQueryValidator(){
            RuleFor(query => query.ActorMovieId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}