using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace WebApi.UnitTests.GenreOperation.Commands.CreateGenre{
    public class CreateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        

        public CreateGenreCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            
        }
        [Fact]
        public void WhenGivenGenreNameAlreadyExistsInDb_InvalidOperationException_ShouldBeReturn(){
            // arrange
            var genre = new Genre{
                Name = "testName"
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            var command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreViewModel{
                Name = genre.Name
            };

            // act - assert
            FluentActions
                .Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should()
                .Be("Tür zaten kayıtlı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated(){
            // arrange
            var command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreViewModel{
                Name = "testName"
            };
            
            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // assert
            var genreCreated = _context.Genres.SingleOrDefault(x => 
                x.Name == command.Model.Name);

            genreCreated.Should().NotBeNull();
            genreCreated.Name.Should().Be(command.Model.Name);
        }
    }
}