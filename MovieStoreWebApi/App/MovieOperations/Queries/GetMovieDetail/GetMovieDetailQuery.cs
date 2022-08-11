using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.App.MovieOperations.Queries;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.MovieOperations.Queries.GetMovieDetail{
    public class GetMovieDetailQuery{
        private readonly IMovieStoreDbContext _dbContext;
        private IMapper _mapper;
        public int Id { get; set; }
        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context; 
            _mapper = mapper;
        }

        public MovieViewModel Handle(){
            var movie = _dbContext.Movies
                .Include(a => a.Actors)
                .ThenInclude(s => s.Actor)
                .Include(a => a.DirectorMovies)
                .ThenInclude(s => s.Director)
                .Include(a => a.Genre)
                .SingleOrDefault(x => x.Id == Id);
            if(movie is null)
                throw new InvalidOperationException("Film bulunamadı");
            
            MovieViewModel vm = _mapper.Map<MovieViewModel>(movie);

            return vm;
        }
    }
}