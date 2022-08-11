using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Commands.DeleteCustomer;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Commands.DeleteCustomer{
    public class DeleteCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenGivenCustomerIdIsNotGreaterThanZero_Validator_ShouldReturnError(int customerId){
            // Arrange
            var command = new DeleteCustomerCommand(null);
            command.id = customerId;

            // Act
            var validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void WhenGivenCustomerIdIsGreaterThanZero_Validator_ShouldNotReturnError(){
            // Arrange 
            var command = new DeleteCustomerCommand(null);
            command.id = 1;

            // Act
            var validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}