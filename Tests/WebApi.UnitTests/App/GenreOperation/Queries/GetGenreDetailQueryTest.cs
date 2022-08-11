using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.GenreOperations.Queries.GetGenreDetail;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.GenreOperation.Queries{
    public class GetGenreDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQueryTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenGenreIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturn(){
            // arrange 
            var genre = new Genre{
                Name = "testGenre"
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            var query = new GetGenreDetailQuery(_context,_mapper);
            query.Id = genre.Id;

            // act - assert
            FluentActions
                .Invoking(() =>query.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should()
                .Be("Tür bulunamadı.");
        }

        [Fact]
        public void WhenGivenGenreIdDoesExistInDb_Genre_ShouldBeReturned()
        {
            // arrange
            var genre = new Genre{
                Name= "WhenGivenGenreIdDoesExistInDb_Genre_ShouldBeReturned"
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            var query = new GetGenreDetailQuery(_context,_mapper);
            query.Id = genre.Id;
            

            // act
            var newGenre = FluentActions.Invoking(() =>query.Handle()).Invoke();
        
            // assert
            newGenre.Should().NotBeNull();
            newGenre.Id.Should().Be(query.Id);
            newGenre.Name.Should().Be(genre.Name);
            
        }
    }
}