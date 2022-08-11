using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.GenreOperations.Queries.GetGenre{
    public class GetGenreQuery{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetGenreViewModel> Handle(){
            var genreList = _dbContext.Genres.OrderBy(x => x.Id).ToList<Genre>();
            List<GetGenreViewModel> vm = _mapper.Map<List<GetGenreViewModel>>(genreList);

            return vm;
        }
    }
    public class GetGenreViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}