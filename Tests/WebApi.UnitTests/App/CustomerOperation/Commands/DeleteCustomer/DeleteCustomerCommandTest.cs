using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Commands.DeleteCustomer{
    public class DeleteCustomerCommandTest : IClassFixture<CommonTestFixture>{
        private readonly MovieStoreDbContext _context;
        public DeleteCustomerCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Fact]
        public void WhenNotExistCustomerIdIsGiven_InvalidOperationException_ShouldBeReturnErrors(){

            // Arrange
            var command = new DeleteCustomerCommand(_context);
            command.id = 0;

            // Act - Assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silmek istediğiniz kullanıcı bulunamadı.");
        }

        [Fact]
        public void WhenGivenCustomerIdExistsInDb_Customer_ShouldBeDeleted(){
            // Arrange
            var customerInDb = new Customer{
                Name = "WhenGivenCustomerIdExistsInDb_Customer_ShouldBeDeleted",
                Surname = "WhenGivenCustomerIdExistsInDb_Customer_ShouldBeDeleted",
                Password = "WhenGivenCustomerIdExistsInDb_Customer_ShouldBeDeleted",
                Email = "WhenGivenCustomerIdExistsInDb_Customer_ShouldBeDeleted"
            };
            _context.Customers.Add(customerInDb);
            _context.SaveChanges();

            var command = new DeleteCustomerCommand(_context);
            command.id = customerInDb.Id;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var customer = _context.Customers.SingleOrDefault(x => x.Id == command.id);
            customer.Should().BeNull();
            
            

        }
    }
}