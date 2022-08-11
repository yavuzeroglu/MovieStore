using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Commands.CreateDirector{
    public class CreateDirectorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenDirectorNameAlreadyExistsInDb_InvalidOperationException_ShouldBeReturn(){
            // arrange
            var director = new Director{
                Name = "testName", Surname = "testSurname"
            };
            _context.Directors.Add(director);
            _context.SaveChanges();

            var command = new CreateDirectorCommand(_context,_mapper);
            command.Model = new CreateDirectorViewModel{
                Name = director.Name, Surname = director.Surname
            };

            // act - assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should()
                .Be("Yönetmen zaten kayıtlı");
            
        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeCreated(){
            // arrange 
            var command = new CreateDirectorCommand(_context,_mapper);
            command.Model = new CreateDirectorViewModel{
                Name = "testName", Surname = "testSurname"
            };

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // assert

            var actorCreated = _context.Directors.SingleOrDefault(x => x.Name == command.Model.Name && x.Surname == command.Model.Surname);

            actorCreated.Should().NotBeNull();
            actorCreated.Name.Should().Be(command.Model.Name);
            actorCreated.Surname.Should().Be(command.Model.Surname);
        }
            

    }
}
