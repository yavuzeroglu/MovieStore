using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Commands.CreateFavoriteGenre{
    public class CreateFavoriteGenreCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateFavoriteGenreModel model;
        public CreateFavoriteGenreCommand(IMovieStoreDbContext context, IMapper mapper){
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle(){
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == model.CustomerId);
            var genre = _dbContext.FavoritesGenres
            .SingleOrDefault(x =>x.GenreId == model.FavoriteGenreId && 
                            x.CustomerId == model.CustomerId);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı");
            else if(genre is not null)
                throw new InvalidOperationException("Tür zaten favorilerde mevcut");

            //FavoritesGenre favGenre = _mapper.Map<FavoritesGenre>(model);
            FavoritesGenre favoritesGenre = new FavoritesGenre();
            favoritesGenre.CustomerId = model.CustomerId;
            favoritesGenre.GenreId = model.FavoriteGenreId;

            _dbContext.FavoritesGenres.Add(favoritesGenre);
            _dbContext.SaveChanges();
        }
    }
    public class CreateFavoriteGenreModel{
        public int CustomerId { get; set; }
        public int FavoriteGenreId { get; set; }
        
    }
}