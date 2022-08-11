using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Queries.GetPurchasedMovies;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Queries.GetPurchasedMoviesDetail{
    public class GetPurchasedMoviesDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetPurchasedMoviesDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetPurchasedMoviesModel Handle(){
            var customer = _dbContext.Customers
                .Include(i => i.PurchasedMovies)
                .ThenInclude(t => t.Movie)
                .SingleOrDefault(x => x.Id == Id);

            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı");
            var vm = _mapper.Map<GetPurchasedMoviesModel>(customer);

            return vm;
            
        }
    }
}