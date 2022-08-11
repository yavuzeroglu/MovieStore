using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.DirectorOperation.Queries{
    public class GetDirectorDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public GetDirectorDetailQueryTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenDirectorIdDoesNotExistInDb_InvalidOperationValidator_ShouldBeReturn(){
            // Arrange
            var director = new Director{
                Name = "WhenGivenDirectorIdDoesNotExistInDb_InvalidOperationValidator_ShouldBeReturn",
                Surname = "WhenGivenDirectorIdDoesNotExistInDb_InvalidOperationValidator_ShouldBeReturn"
            };
            _context.Directors.Add(director);
            _context.SaveChanges();

            _context.Directors.Remove(director);
            _context.SaveChanges();

            var command = new GetDirectorDetailQuery(_context,_mapper);
            command.Id = director.Id;
            // Act - Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen bulunamadı.");
        }

        [Fact]
        public void WhenGivenDirectorIdDoesExistInDb_Director_ShouldBeReturned(){
            // Arrange
            var director = new Director {
                Name = "TestName", Surname = "TestSurname"
            };
            _context.Directors.Add(director);
            _context.SaveChanges();

            var command = new GetDirectorDetailQuery(_context,_mapper);
            command.Id = director.Id;

            // Act 
            var returnDirector = FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            returnDirector.Should().NotBeNull();
            returnDirector.Id.Should().Be(command.Id);
            returnDirector.Name.Should().Be(director.Name);
            returnDirector.Surname.Should().Be(director.Surname);

        }
    }
}