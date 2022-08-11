using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Queries.GetGenreDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.GenreOperation.Queries{
    public class GetGenreDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenGivenGenreIdIsNotGreaterThanZero_Validator_ShouldBeReturnError(){
            // Arrange
            var query = new GetGenreDetailQuery(null,null);
            query.Id = 0;

            // Act 
            var validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenGivenGenreIdIsGreaterThanZero_Validator_ShouldNotReturnError(){
            // Arrange
            var query = new GetGenreDetailQuery(null,null);
            query.Id = 1;

            // Act
            var validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}