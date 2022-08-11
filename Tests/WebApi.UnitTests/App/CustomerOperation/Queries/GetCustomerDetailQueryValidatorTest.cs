using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Queries{
    public class GetCustomerDetailQueryValidatorTest : IClassFixture<CommonTestFixture>{

        [Fact]
        public void WhenGivenCustomerIdIsNotGreaterThanZero_Validator_ShouldBeReturnError(){

            // Arrange
            var query = new GetCustomerDetailQuery(null,null);
            query.Id = 0;

            // Act
            var validator = new GetCustomerDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenGivenCustomerIdGreaterThanZero_Validator_ShouldBeReturnError(){
            // Arrange 
            var query = new GetCustomerDetailQuery(null,null);
            query.Id = 1;

            // Act
            var validator = new GetCustomerDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}