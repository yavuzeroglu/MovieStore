using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Commands.UpdateActor;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Commnads.UpdateActor{
    public class UpdateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, null, null)]
        [InlineData(0, "", null)]
        [InlineData(0, "Nu", null)]
        [InlineData(0, null, "")]
        [InlineData(1, null, "su")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int actorId, string name, string surname){
            // Arrange
            var command = new UpdateActorCommand(null);
            command.ActorId = actorId;
            command.Model = new UpdateActorModel{ Name = name, Surname = surname };

            // Act
            var validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError(){
            // Arrange
            var command = new UpdateActorCommand(null);
            command.ActorId = 1;
            command.Model = new UpdateActorModel{
                Name = "WhenValidInputsAreGiven",
                Surname = "ShouldNotReturnError"
            };

            // Act
            var validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}