using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorMoviesOperations.Queries.GetActorMovieDetail;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorMoviesOperation.Queries
{
    public class GetActorMoviesDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorMoviesDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenActorMovieIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturn()
        {

            // Arrange
            var query = new GetActorMovieDetailQuery(_context, _mapper);
            query.ActorMovieId = -1;

            // Act - Assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kayıt bulunamadı");
        }

        [Fact]
        public void WhenGivenActorMovieIdDoesExistInDb_ActorMovie_ShouldBeReturned()
        {
            // Arrange
            var query = new GetActorMovieDetailQuery(_context, _mapper);
            query.ActorMovieId = 1;
            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var actorMovie = _context.ActorMovies.SingleOrDefault(x => x.Id == 1);
            actorMovie.Should().NotBeNull();
        }
    }
}