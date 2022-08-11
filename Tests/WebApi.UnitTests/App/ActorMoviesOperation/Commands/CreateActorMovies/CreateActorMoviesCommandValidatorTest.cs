using FluentAssertions;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.CreateActorMovie;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorMoviesOperation.Commands.CreateActorMovies{
    public class CreateActorMoviesCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,0)]
        [InlineData(0,1)]
        [InlineData(null,1)]
        [InlineData(1,null)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int movieId, int actorId){
            // Arrange
            var command = new CreateActorMovieCommand(null,null);
            command.model = new CreateActorMovieViewModel(){
                MovieId = movieId,
                ActorId = actorId
            };

            // Act
            var validator = new CreateActorMovieCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1,1)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int movieId, int actorId){
            // Arrange
            var command = new CreateActorMovieCommand(null,null);
            command.model = new CreateActorMovieViewModel(){
                MovieId = movieId,
                ActorId = actorId
            };
            
            // Act
            var validator = new CreateActorMovieCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);

        }
        
    }
}