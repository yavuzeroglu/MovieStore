using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Commands.UpdateActor;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Commnads.UpdateActor{
    public class UpdateActorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
    
        public UpdateActorCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenNotExistActorIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError(){
            // Arrange
            var model = new UpdateActorModel() {
                Name = "test", Surname = "test"
            };
            // Act
            var command = new UpdateActorCommand(_context);
            command.Model = model;

            // Assert
            FluentActions.
                Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu bulunamadı");
        }

        [Fact]
        public void WhenAlreadyExistActorIdAndModelAreGiven_Update_ShouldBeUpdateActorMovies(){
            // Arrange
            var model = new UpdateActorModel(){
                Name = "test", Surname = "test" };
            var command = new UpdateActorCommand(_context);
            command.Model = model;
            command.ActorId = 1;
            
            // Act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();
            
            // Assert
            var actor = _context.Actors.SingleOrDefault(x => x.Id == 1);

            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.Surname.Should().Be(model.Surname);
        }
    }


}