using FluentAssertions;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.UpdateActorMovie;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorMoviesOperation.Commands.UpdateActorMovies{
    public class UpdateActorMoviesCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1,0,0)]
        [InlineData(1,1,0)]
        [InlineData(1,0,1)]
        [InlineData(1,null,1)]
        [InlineData(1,1,null)]
        [InlineData(0,1,1)]
        [InlineData(null,1,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int actorMovieId, int movieId, int ActorId){
            // arrange
            var command = new UpdateActorMovieCommand(null);
            command.model = new UpdateActorMovieModel(){
                MovieId = movieId,
                ActorId = ActorId
            };
            command.Id = actorMovieId;


            // Act
            var validator = new UpdateActorMovieCommandValidator();
            var result = validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0); 
        }

        [Theory]
        [InlineData(1,1,1)]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnErrors(int actorMovieId, int ActorId, int MovieId){
            var command = new UpdateActorMovieCommand(null);
            command.model = new UpdateActorMovieModel(){
                ActorId = ActorId,
                MovieId = MovieId
            };
            command.Id = actorMovieId;

            var validator = new UpdateActorMovieCommandValidator();
            var result = validator.Validate(command);


            result.Errors.Count.Should().Be(0);
        }
    }
}