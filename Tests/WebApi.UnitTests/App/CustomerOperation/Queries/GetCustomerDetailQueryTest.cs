using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomerDetail;
using MovieStoreWebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.CustomerOperation.Queries{
    public class GetCustomerDetailQueryTest : IClassFixture<CommonTestFixture>{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
    
        public GetCustomerDetailQueryTest(CommonTestFixture testFixture){
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenCustomerIdDoesNotExistInDb_InvalidOperationException_ShouldBeReturn(){
            // Arrange 
            var query = new GetCustomerDetailQuery(_context,_mapper);
            query.Id = -1;
            
            // Act - Assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı");
            
        }
    
    }
}