using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Commands.UpdateGenre;
using WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace WebApi.UnitTests.GenreOperation.Commands.UpdateGenre{
    public class UpdateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,null)]
        [InlineData(0,"")]
        [InlineData(1,"")]
        [InlineData(1,"t")]
        [InlineData(0,"te")]
        [InlineData(0,"tes")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int genreId, string name){
            var command = new UpdateGenreCommand(null);
            command.Id = genreId;
            command.Model = new CreateGenreViewModel{
                Name = name
            };

            var validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError(){
            var command = new UpdateGenreCommand(null);
            command.Id = 1;
            command.Model = new CreateGenreViewModel{
                Name = "testGenre"
            };

            var validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}