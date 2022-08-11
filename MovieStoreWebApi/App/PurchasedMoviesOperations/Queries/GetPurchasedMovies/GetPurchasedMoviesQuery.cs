using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Queries.GetPurchasedMovies{
    public class GetPurchasedMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetPurchasedMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetPurchasedMoviesModel> Handle(){
            var list = _dbContext.Customers
                .Include(i => i.PurchasedMovies)
                .ThenInclude(t => t.Movie)
                .Where(w => w.PurchasedMovies.Any(a => a.movieStatus == true))
                .OrderBy(x => x.Id).ToList();

            var vm = _mapper.Map<List<GetPurchasedMoviesModel>>(list);

            return vm;
            
        }
    }

    public class GetPurchasedMoviesModel{
        public string FullName { get; set; }
        public IReadOnlyCollection<string> Movies { get; set; }
        public IReadOnlyCollection<string> Price { get; set; }
        public IReadOnlyCollection<string> PurchasedDate { get; set; }
    }
}