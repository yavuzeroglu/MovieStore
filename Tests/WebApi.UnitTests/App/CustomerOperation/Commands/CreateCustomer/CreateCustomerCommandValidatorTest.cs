using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Commands.CreateCustomer;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Commands.CreateCustomer{
    public class CreateCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","","","")]
        [InlineData("","test","test","test")]
        [InlineData("test","","test","test")]
        [InlineData("test","test","","test")]
        [InlineData("test","test","test","")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(string name, string surname, string email, string password){
            // Arrange
            var command = new CreateCustomerCommand(null,null);
            command.model = new CreateCustomerViewModel(){
                Name = name,
                Surname = surname,
                Email = email,
                Password = password
            };

            // Act
            var validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}