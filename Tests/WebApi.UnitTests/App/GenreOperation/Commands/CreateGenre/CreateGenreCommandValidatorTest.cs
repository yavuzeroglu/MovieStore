using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre;
using WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace WebApi.UnitTests.GenreOperation.Commands.CreateGenre{
    public class CreateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("te")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name){
            var command = new CreateGenreCommand(null);
            command.Model = new CreateGenreViewModel{
                Name = name
            };

            var validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}