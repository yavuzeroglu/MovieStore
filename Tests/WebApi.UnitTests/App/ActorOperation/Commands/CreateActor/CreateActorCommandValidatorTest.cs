using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Commands.CreateActor;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Commnads.CreateActor{
    public class CreateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(null, "Surname")]
        [InlineData("", "Surname")]
        [InlineData("N", "Surname")]
        [InlineData("Na", null)]
        [InlineData("Nam", "")]
        [InlineData("Nam", "S")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname){
            // Arrange 
            var command = new CreateActorCommand(null,null);
            command.Model = new CreateActorModel()
            { 
                Name = name, Surname = surname 
            };

            // Act
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var results = validator.Validate(command);

            // Assert
            results.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}