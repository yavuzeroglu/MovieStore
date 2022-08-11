using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Commands.CreateCustomer{
    public class CreateCustomerCommandTest : IClassFixture<CommonTestFixture>{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
    
        public CreateCustomerCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenCustomerEmailAlreadyExistsInDb_InvalidOperationException_ShouldBeReturn(){
            
            // Arrange
            var customer = 
                new Customer{
                    Name= "TestName", Surname = "TestSurname", Email = "TestMail", Password = "TestPassword"
                };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var command = new CreateCustomerCommand(_context,_mapper);
            command.model = new CreateCustomerViewModel{
                Name = customer.Name,
                Surname = customer.Surname,
                Email = customer.Email,
                Password = customer.Password
            };

            // Act - Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Mail Adresine kayıtlı kullanıcı zaten mevcut");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeCreated(){
            // Arrange
            var command = new CreateCustomerCommand(_context,_mapper);
            command.model = new CreateCustomerViewModel{
                Name = "WhenValidInputsAreGiven", Surname = "WhenValidInputsAreGiven", Email="WhenValidInputsAreGiven", Password ="WhenValidInputsAreGiven"
            };

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var newCustomer = _context.Customers.SingleOrDefault(c => 
                c.Name == command.model.Name && c.Surname == command.model.Surname);

            newCustomer.Should().NotBeNull();
            newCustomer.Name.Should().Be(command.model.Name);
            newCustomer.Surname.Should().Be(command.model.Surname);  
            newCustomer.Email.Should().Be(command.model.Email);
            newCustomer.Password.Should().Be(command.model.Password);
        }
    
    }
}