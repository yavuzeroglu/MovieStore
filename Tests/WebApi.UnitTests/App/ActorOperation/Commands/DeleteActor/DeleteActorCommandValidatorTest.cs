using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Commands.DeleteActor;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Commnads.DeleteActor{
    public class DeleteActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int actorMovieId){
            // Arrange
            var command = new DeleteActorCommand(null);
            command.ActorId = actorMovieId;

            // Act
            var validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotError(int actorMovieId){
            // Arrange
            var command = new DeleteActorCommand(null);
            command.ActorId = actorMovieId;
            // Act
            var validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);
            // Assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}