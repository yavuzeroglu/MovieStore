using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Commands.UpdateGenre;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace WebApi.UnitTests.GenreOperation.Commands.UpdateGenre{
    public class UpdateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        

        public UpdateGenreCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Fact]
        public void WhenGivenGenreIdDoesNotExistsInDb_InvalidOperationException_ShouldBeReturn(){
            // Arrange
            var command = new UpdateGenreCommand(_context);
            command.Id = -1;

            // Act - Assert
            FluentActions
                .Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should()
                .Be("Tür bulunamadı");
        }

        [Fact]
        public void WhenGivenGenreIdExistsInDb_Genre_ShouldBeUpdated(){
            // Arrange
            var genreInDb = new Genre{ Name = "testGenre" };
            var genreCompared = new Genre{ Name = genreInDb.Name };

            _context.Genres.Add(genreInDb);
            _context.SaveChanges();

            var command = new UpdateGenreCommand(_context);
            command.Id = genreInDb.Id;
            command.Model = new CreateGenreViewModel{
                Name = "testGenre"
            };

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var genreUpdated = _context.Genres.SingleOrDefault(x => x.Id == genreInDb.Id);
            genreUpdated.Should().NotBeNull();
            genreUpdated.Name.Should().Be(genreCompared.Name);
            
        }
    }
}