
using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Commands.UpdateDirector{
    public class UpdateDirectorCommandTest : IClassFixture<CommonTestFixture>{
        private readonly MovieStoreDbContext _context;
        

        public UpdateDirectorCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

    [Fact]
    public void WhenGivenDirectorIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturnError(){
        // Arrange
        var command = new UpdateDirectorCommand(_context);
        command.Id = -1;

        // Act - Assert
        FluentActions
            .Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Yönetmen bulunamadı");

    }


    }
}