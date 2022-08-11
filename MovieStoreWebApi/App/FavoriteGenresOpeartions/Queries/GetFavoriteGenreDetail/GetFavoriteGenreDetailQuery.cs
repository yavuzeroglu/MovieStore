using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.App.FavoriteGenreOperations.Queries.GetFavoriteGenre;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Queries.GetFavoriteGenreDetail{
    public class GetFavoriteGenreDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetFavoriteGenreDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetFavoriteGenreViewModel Handle(){
            var customer = _dbContext.Customers
                .Include(i => i.FavoritesGenres)
                .ThenInclude(t => t.Genre)
                .SingleOrDefault(x => x.Id == Id);
            var vm = _mapper.Map<GetFavoriteGenreViewModel>(customer);
            return vm;
        }
    }
}