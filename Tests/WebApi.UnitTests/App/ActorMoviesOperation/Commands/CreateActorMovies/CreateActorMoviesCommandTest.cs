using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.CreateActorMovie;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorMoviesOperation.Commands.CreateActorMovies
{
    public class CreateActorMoviesCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorMoviesCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenNotExistActorIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            // Arrange
            var model = new CreateActorMovieViewModel()
            {
                ActorId = 0,
                MovieId = 1
            };

            // Act
            var command = new CreateActorMovieCommand(_context, _mapper);
            command.model = model;

            // Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu bulunamadı");
        }

        [Fact]
        public void WhenNotExistMovieIdModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            // Arrange
            var model = new CreateActorMovieViewModel()
            {
                ActorId = 1,
                MovieId = 1
            };

            // Act
            var command = new CreateActorMovieCommand(_context, _mapper);
            command.model = model;

            // Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu daha önce bu filme zaten eklenmiş");
        }

        [Fact]
        public void WhenNotExistMovieAndActorIdIsGiven_Create_ShouldBeCreateActorMovie()
        {
            // Arrange
            var model = new CreateActorMovieViewModel() 
                { ActorId = 3, MovieId = 4 };
            var command = new CreateActorMovieCommand(_context,_mapper);
            command.model = model;
            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var actorMovie = _context.ActorMovies.SingleOrDefault(x => x.ActorId == model.ActorId && x.MovieId == model.MovieId);

            actorMovie.Should().NotBeNull();
            actorMovie.ActorId.Should().Be(model.ActorId);
            actorMovie.MovieId.Should().Be(model.MovieId);
        }
    }
}