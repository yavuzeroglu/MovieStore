using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.DeleteActorMovie;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorMoviesOperation.Commands.DeleteActorMovies{
    public class DeleteActorMoviesCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteActorMoviesCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenNotExistActorMovieIsGiven_InvalidOperationException_ShouldBeReturnErrors(){
            
            var command = new DeleteActorMovieCommand(_context);
            command.Id = 0;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Kayıt bulunamadı");
        }
    
    }

}