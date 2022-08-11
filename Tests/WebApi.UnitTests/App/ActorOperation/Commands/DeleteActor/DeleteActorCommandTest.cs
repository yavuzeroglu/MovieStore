using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Commands.DeleteActor;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Commnads.DeleteActor{
    public class DeleteActorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public DeleteActorCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenActorIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturn(){
            // Arrange
            var command = new DeleteActorCommand(_context);
            command.ActorId = -1;

            // Act - Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Aktör bulunamadı");
        }
        
    }
}