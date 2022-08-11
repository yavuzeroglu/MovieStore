using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.DeletePurchasedMovies
{
    public class DeletePurchasedMoviesCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }

        public DeletePurchasedMoviesCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var purchasedMovie = _dbContext.PurchasedMovies.SingleOrDefault(x => x.Id == Id);
            if(purchasedMovie is null)
                throw new InvalidOperationException("Kayıt bulunamadı.");

            purchasedMovie.movieStatus = false;

            _dbContext.PurchasedMovies.Update(purchasedMovie);
            _dbContext.SaveChanges();  
        }
    }
}