using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.FavoriteGenreOperations.Queries.GetFavoriteGenre
{
    public class GetFavoriteGenreQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFavoriteGenreQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetFavoriteGenreViewModel> Handle()
        {
             var favGenreList = _dbContext.Customers
                 .Include(x => x.FavoritesGenres)
                 .ThenInclude(t => t.Genre)
                 .OrderBy(x => x.Id).ToList();
            
            List<GetFavoriteGenreViewModel> vm = _mapper.Map<List<GetFavoriteGenreViewModel>>(favGenreList);

            return vm;
        }

    }
    public class GetFavoriteGenreViewModel
    {
        public string Customer { get; set; }
        public IReadOnlyCollection<string> Genres { get; set; }
    }
}