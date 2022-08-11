using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.UpdatePurchasedMovies{
    public class UpdatePurchasedMoviesCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdatePurchasedMoviesModel model { get; set; }
        public UpdatePurchasedMoviesCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var purchasedMovies = _dbContext.PurchasedMovies.SingleOrDefault(x => x.Id == Id);
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == model.MovieId);
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == model.CustomerId);
            var checkPurchasedMovie = _dbContext.PurchasedMovies.SingleOrDefault(x => x.CustomerId == model.CustomerId && x.MovieId == model.MovieId);

            if(purchasedMovies is null)
                throw new InvalidOperationException("Kayıt bulunamadı");
            else if(movie is null)
                throw new InvalidOperationException("Film bulunamadı");
            else if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı");
            else if(checkPurchasedMovie is not null)
                throw new InvalidOperationException("Müşteri bu filmi daha önce satın almış");

            purchasedMovies.CustomerId = model.CustomerId == default ? purchasedMovies.CustomerId : model.CustomerId;
            purchasedMovies.MovieId = model.MovieId == default ? purchasedMovies.MovieId : model.MovieId;

            _dbContext.PurchasedMovies.Update(purchasedMovies);
            _dbContext.SaveChanges();
            

        }
    }
    public class UpdatePurchasedMoviesModel{
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        DateTime purchasedTime = DateTime.Now;
        bool movieStatus = true;
    }
}