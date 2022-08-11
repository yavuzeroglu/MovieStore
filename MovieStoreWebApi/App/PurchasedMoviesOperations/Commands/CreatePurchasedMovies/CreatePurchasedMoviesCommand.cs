using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.CreatePurchasedMovies{
    public class CreatePurchasedMoviesCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreatePurchasedMoviesModel model;
        public CreatePurchasedMoviesCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == model.CustomerId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            var purchasedMovie = _dbContext.PurchasedMovies.SingleOrDefault(s => s.CustomerId == model.CustomerId && s.MovieId == model.MovieId);

            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı");
            else if(movies is null)
                throw new InvalidOperationException("Film bulunamadı");
            else if(purchasedMovie is not null)
                throw new InvalidOperationException("Müşteri bu filmi daha önce satın almış");

            var result = new PurchasedMovies();
            result.CustomerId = model.CustomerId;
            result.MovieId = model.MovieId;
            result.movieStatus = model.movieStatus;
            result.purchasedTime = model.purchasedTime;
            
            _dbContext.PurchasedMovies.Add(result);
            _dbContext.SaveChanges();

            

        }
    }
    public class CreatePurchasedMoviesModel{
       public int CustomerId { get; set; }
       public int MovieId { get; set; }
        
       public DateTime purchasedTime = DateTime.Now;
       public bool movieStatus = true; 
    }
}