using AutoMapper;
using MovieStoreWebApi.App.GenreOperations.Queries.GetGenre;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.GenreOperations.Queries.GetGenreDetail{
    public class GetGenreDetailQuery{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetGenreDetailQuery(IMovieStoreDbContext context, IMapper mapper){
            _dbContext = context;
            _mapper = mapper;
        }

        public GetGenreViewModel Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Id);
            if(genre is null)
                throw new InvalidOperationException("Tür bulunamadı.");
            
            GetGenreViewModel vm = _mapper.Map<GetGenreViewModel>(genre);

            return vm;
        } 
    }
}