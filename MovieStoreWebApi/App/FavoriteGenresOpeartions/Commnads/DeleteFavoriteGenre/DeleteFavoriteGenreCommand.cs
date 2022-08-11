using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Commands.DeleteFavoriteGenre
{
    public class DeleteFavoriteGenreCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }
        public DeleteFavoriteGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var favGenre = _dbContext.FavoritesGenres.SingleOrDefault(x => x.Id == Id);
            if(favGenre is null)
                throw new InvalidOperationException("Favori Tür kaydı bulunamadı");

            _dbContext.FavoritesGenres.Remove(favGenre);
            _dbContext.SaveChanges();
        }
    }
}