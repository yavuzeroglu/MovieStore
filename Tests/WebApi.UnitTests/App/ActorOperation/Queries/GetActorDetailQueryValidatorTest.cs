using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Queries.GetActorDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Queries
{
    public class GetActorDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenGivenActorIdIsNotGreaterThanZero_Validator_ShouldBeReturnError()
        {

            // Arrange
            var query = new GetActorDetailQuery(null, null);
            query.ActorId = 0;

            // Act
            var validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenGivenActorIdGreaterThanZero_Validator_ShouldNotReturnZero()
        {
            // Arrange
            var query = new GetActorDetailQuery(null, null);
            query.ActorId = 1;

            // Act
            var validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}