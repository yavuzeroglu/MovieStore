using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Commands.UpdateDirector;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Commands.UpdateDirector{
    public class UpdateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"","")]
        [InlineData(0,"null","")]
        [InlineData(0,"","null")]
        [InlineData(1,"","")]
        [InlineData(0,"null","null")]
        [InlineData(1,"","null")]
        [InlineData(1,"null","")]
        [InlineData(1,"nu","nu")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int directorId, string name, string surname){
            
            // Arrange
            var command = new UpdateDirectorCommand(null);
            command.Id = directorId;
            command.Model = new UpdateDirectorViewModel{
                Name = name, Surname = surname
            };

            // Act
            var validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}