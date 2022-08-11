using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Commands.DeleteDirector;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Commands.DeleteDirector{
    public class DeleteDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenGivenDirectorIdIsNotGreaterThanZero_Validator_ShouldBeReturnError(int directorId){
            // arrange 
            var command = new DeleteDirectorCommand(null);
            command.Id = directorId;

            // act
            var validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0); 
        }
        [Fact]
        public void WhenGivenDirectorIdIsGreaterThanZero_Validator_ShouldNotReturnError(){
            // arrange
            var command = new DeleteDirectorCommand(null);
            command.Id = 1;

            // act 
            var validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            // assert
            result.Errors.Count.Should().Be(0);
        }
    }
}