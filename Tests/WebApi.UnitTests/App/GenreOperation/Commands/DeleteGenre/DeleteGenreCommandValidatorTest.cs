using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Commands.DeleteGenre;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.GenreOperation.Commands.DeleteGenre{
    public class DeleteGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenGivenGenreIdIsNotGreaterThanZero_Validator_ShouldBeReturnErrors(int genreId){
            var command = new DeleteGenreCommand(null);
            command.Id = genreId;

            var validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenGivenGenreIdIsGreaterThanZero_Validator_ShouldNotReturnError(){
            var command = new DeleteGenreCommand(null);
            command.Id = 1;
            
            var validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}