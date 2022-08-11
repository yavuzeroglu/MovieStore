using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Commnads.CreateActor{
    public class CreateActorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }
        [Fact]
        public void WhenGivenActorNameAlreadyExistsIndDb_InvalidOperationException_ShouldBeReturn(){
            // arrange
            var actor = new Actor{
                Name = "testName", Surname = "testSurname"
            };

            _context.Actors.Add(actor);
            _context.SaveChanges();

            var command = new CreateActorCommand(_context,_mapper);
            command.Model = new CreateActorModel {
                Name = actor.Name, Surname = actor.Surname
            };

            // act - assert
            FluentActions
                .Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu zaten mevcut");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeCreated(){
            // arrange
            var model = new CreateActorModel(){
                Name = "testName", Surname = "testSurname"
            };
            var command = new CreateActorCommand(_context, _mapper);
            command.Model = model;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // assert
            var actor = _context.Actors.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);

            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.Surname.Should().Be(model.Surname);
            
        }
    }
}