using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.UpdateActorMovie;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorMoviesOperation.Commands.UpdateActorMovies
{
    public class UpdateActorMoviesCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;


        public UpdateActorMoviesCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.context;

        }


        [Fact]
        public void WhenNotExistActorIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            // Arrange
            var model = new UpdateActorMovieModel()
            {
                ActorId = 0,
                MovieId = 1
            };

            // Act
            var command = new UpdateActorMovieCommand(_context);
            command.model = model;

            // Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu bulunamadı");

        }

        [Fact]
        public void WhenNotExistMovieIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            // Arrange
            var model = new UpdateActorMovieModel()
            {
                ActorId = 1,
                MovieId = 0
            };

            // Act
            var command = new UpdateActorMovieCommand(_context);
            command.model = model;

            // Assert
            FluentActions
                .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film bulunamadı");
        }

        [Fact]
        public void WhenNotExistMovieAndActorIdIsGiven_Update_ShouldBeUpdateActorMovies()
        {
            // Arrange
            var model = new UpdateActorMovieModel() { ActorId = 3, MovieId = 4 };
            var command = new UpdateActorMovieCommand(_context);
            command.model = model;
            command.Id = 1;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var actorMovies = _context.ActorMovies.SingleOrDefault(x => x.Id == 1);
            actorMovies.Should().NotBeNull();
            actorMovies.ActorId.Should().Be(model.ActorId);
            actorMovies.MovieId.Should().Be(model.MovieId);
        }
    }
}