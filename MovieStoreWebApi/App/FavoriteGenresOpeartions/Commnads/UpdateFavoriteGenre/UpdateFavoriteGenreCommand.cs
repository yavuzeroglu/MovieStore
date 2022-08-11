using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Commands.UpdateFavoriteGenre
{
    public class UpdateFavoriteGenreCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateFavoriteGenreModel Model { get; set; }

        public UpdateFavoriteGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var favoriteGenre = _dbContext.FavoritesGenres.SingleOrDefault(x => x.Id == Id);
            var customerFavGenreList = _dbContext.FavoritesGenres.Where(x => x.Id == favoriteGenre.CustomerId);
            bool checkGenre = false;

            foreach (var item in customerFavGenreList)
            {
                var result = item.GenreId;
                checkGenre = result == Model.FavoriteGenreId ? true : false;
            }

            if(checkGenre)
                throw new InvalidOperationException("Tür zaten favorilerde mevcut");
            else if(favoriteGenre is null)
                throw new InvalidOperationException("Kayıt bulunamadı");

            favoriteGenre.GenreId = 
            Model.FavoriteGenreId == default ? favoriteGenre.GenreId : Model.FavoriteGenreId;

            _dbContext.FavoritesGenres.Update(favoriteGenre);
            _dbContext.SaveChanges(); 
        }
    }
    public class UpdateFavoriteGenreModel
    {
        public int FavoriteGenreId { get; set; }
    }
}