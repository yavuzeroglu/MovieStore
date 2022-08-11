using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Commands.UpdateCustomer;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "test", "test", "test@mail.com", "testPass")]
        [InlineData(1, "", "test", "test@mail", "testPass")]
        [InlineData(1, "test", "", "test@mail", "testPass")]
        [InlineData(1, "test", "test", "", "testPass")]
        [InlineData(1, "test", "test", "test@mail", "")]
        
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int customerId, string name, string surname, string email, string password)
        {

            // Arrange
            var command = new UpdateCustomerCommand(null);
            command.Id = customerId;
            command.Model = new UpdateCustomerViewModel
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password
            };

            // Act
            var validator = new UpdateCustomerCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1,"testName","testSurname","test@mail.com","testPass")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError(int customerId, string name, string surname, string email, string password){
            // Arrange
            var command = new UpdateCustomerCommand(null);
            command.Id = customerId;
            command.Model = new UpdateCustomerViewModel{
                Name = name, 
                Surname = surname,
                Email = email,
                Password = password
            };

            // Act 
            var validator = new UpdateCustomerCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}