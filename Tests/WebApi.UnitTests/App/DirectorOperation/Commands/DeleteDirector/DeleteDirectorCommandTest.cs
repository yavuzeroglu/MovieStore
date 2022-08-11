using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Commands.DeleteDirector;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Commands.DeleteDirector{
    public class DeleteDirectorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteDirectorCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Fact]
        public void WhenGivenDirectorIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturn(){
            // arrange
            var command = new DeleteDirectorCommand(_context);
            command.Id = 0;

            // Act - Assert
            FluentActions
                .Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should()
                .Be("Yönetmen bulunamadı.");
        }

        [Fact]
        public void WhenGivenDirectorIdDoesExistInDb_Customer_ShouldBeDeleted(){
            // arrange
            var director = new Director{
                Name = "testName", Surname = "testSurname"
            };
            _context.Directors.Add(director);
            _context.SaveChanges();

            var commnad = new DeleteDirectorCommand(_context);
            commnad.Id = director.Id;

            // Act
            FluentActions.Invoking(() => commnad.Handle()).Invoke();

            // assert

            var newDirector = _context.Directors.SingleOrDefault(x => x.Id == commnad.Id);
            newDirector.Should().BeNull();
        }
    }

}