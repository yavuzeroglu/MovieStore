using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;

namespace WebApi.UnitTests.TestSetup{
    public class CommonTestFixture{
        public MovieStoreDbContext context { get; set; }
        public IMapper mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDb").Options;
            context = new MovieStoreDbContext(options);

            context.Database.EnsureCreated();
            context.AddData();
            context.SaveChanges();

            mapper = new MapperConfiguration(cfg =>
                {cfg.AddProfile<MappingProfile>();}).CreateMapper();
            
        }
    }
}