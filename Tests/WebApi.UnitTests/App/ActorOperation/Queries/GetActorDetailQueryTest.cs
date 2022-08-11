using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.ActorOperations.Queries.GetActor;
using MovieStoreWebApi.App.ActorOperations.Queries.GetActorDetail;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.ActorOperations.Queries{
    public class GetActorDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
    
        public GetActorDetailQueryTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;    
        }

        [Fact]
        public void WhenGivenActorIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturn(){
            // Arrange
            var query = new GetActorDetailQuery(_context,_mapper);
            query.ActorId = 999;

            // Act - Assert

            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu bulunamadı");

        }
        
        [Fact]
        public void WhenGivenActorIdDoesExistInDb_Actor_ShouldBeReturned(){
            // Arrange
            var query = new GetActorDetailQuery(_context,_mapper);
            
            query.ActorId = 1; 
            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var actor = _context.Actors.SingleOrDefault(x => x.Id == 1);
            actor.Should().NotBeNull();
        }

    
    }
}