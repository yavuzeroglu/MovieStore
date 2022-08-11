using FluentAssertions;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.DeleteActorMovie;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorMoviesOperation.Commands.DeleteActorMovies{
    public class DeleteActorMoviesCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int actorMovieId){
            var command = new DeleteActorMovieCommand(null);
            command.Id = actorMovieId;

            var validator = new DeleteActorMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeError(int actorMovieId){
            var command = new DeleteActorMovieCommand(null);
            command.Id = actorMovieId;

            var validator = new DeleteActorMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}