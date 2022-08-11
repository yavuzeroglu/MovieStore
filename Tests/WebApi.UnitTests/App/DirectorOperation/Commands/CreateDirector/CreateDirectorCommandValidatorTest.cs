using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Commands.CreateDirector;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Commands.CreateDirector{
    public class CreateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("null", "")]
        [InlineData("", "null")]
        [InlineData("nu", "nu")]
        [InlineData("null", null)]
        [InlineData(null, "null")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname){
            // arrange
            var command = new CreateDirectorCommand(null,null);
            command.Model = new CreateDirectorViewModel{
                Name = name, Surname = surname
            };

            // act 
            var validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            // assert 
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotReturnError(){
            // arrange
            var command = new CreateDirectorCommand(null,null);
            command.Model = new CreateDirectorViewModel{
                Name = "testName", Surname = "testSurname"
            };

            // act
            var validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}