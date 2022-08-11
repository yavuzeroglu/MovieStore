using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Queries{
    public class GetDirectorDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenGivenDirectorIdIsNotGreaterThanZero_Validator_ShouldBeReturnError(){
            // Arrange 
            var query = new GetDirectorDetailQuery(null,null);
            query.Id = 0;

            // Act
            var validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenGivenDirectorIdIsGreaterThanZero_Validator_ShouldNotReturnError(){
            // Arrange
            var query = new GetDirectorDetailQuery(null,null);
            query.Id = 1;

            // act
            var validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            // assert 
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}