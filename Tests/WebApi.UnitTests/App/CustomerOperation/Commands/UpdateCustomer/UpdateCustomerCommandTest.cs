using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Commands.UpdateCustomer;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Commands.UpdateCustomer{
    public class UpdateCustomerCommandTest : IClassFixture<CommonTestFixture>{
        private readonly MovieStoreDbContext _context; 
        

        public UpdateCustomerCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            
        }

        [Fact]
        public void WhenNotExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReturnError(){
            // Arrange
            var command = new UpdateCustomerCommand(_context);
            command.Id = 0;

            // Act - Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı.");
        }

        [Fact]
        public void WhenAlreadyExistCustomerIdAndModelAreGiven_Update_ShouldBeUpdateActorMovies(){
            // Arrange
            var model = new UpdateCustomerViewModel() {
                Name = "testName", Surname = "testSurname",
                Email = "test@mail.com", Password = "test1"
            };
            var command = new UpdateCustomerCommand(_context);
            command.Model = model;
            command.Id = 1;
            
            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var customer = _context.Customers.SingleOrDefault(x => x.Id == 1);

            customer.Should().NotBeNull();
            customer.Name.Should().Be(model.Name);
            customer.Surname.Should().Be(model.Surname);
            customer.Email.Should().Be(model.Email);
            customer.Password.Should().Be(model.Password);
        }
    }
}