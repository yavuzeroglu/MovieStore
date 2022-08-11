using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.MovieOperations.Queries
{
    public class GetMovieQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _dbContext.Movies
                .Include(a => a.Actors)
                .ThenInclude(s => s.Actor)
                .Include(a => a.DirectorMovies)
                .ThenInclude(s => s.Director)
                .Include(a => a.Genre)
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Id).ToList();
            List<MovieViewModel> vm = _mapper.Map<List<MovieViewModel>>(movieList);
            
            return vm;
        }
    }
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }
        public IReadOnlyCollection<string> Director { get; set; }
        public IReadOnlyCollection<string> Actors { get; set; }
    }
}