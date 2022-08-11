using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Commands.DeleteGenre;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.GenreOperation.Commands.DeleteGenre{
    public class DeleteGenreCommandTest : IClassFixture<CommonTestFixture>{
        private readonly MovieStoreDbContext _context;

        public DeleteGenreCommandTest(CommonTestFixture testFixture){
            _context = testFixture.context;
        }

        [Fact]
        public void WhenGivenGenreIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturn(){
            // Arrange
            var command = new DeleteGenreCommand(_context);
            command.Id = 0;

            // Act - Assert
            FluentActions
                .Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should()
                .Be("Tür bulunamadı");
        }
        [Fact]
        public void WhenGivenGenreIdExistsInDb_Genre_ShouldBeDeleted(){
            // Arrange
            var genre = new Genre{
                Name = "testGenre"
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            var command = new DeleteGenreCommand(_context);
            command.Id = genre.Id;

            // Act 
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var deletedGenre = _context.Genres.SingleOrDefault(x => x.Id == command.Id);
            deletedGenre.Should().BeNull();
        }
    }
}