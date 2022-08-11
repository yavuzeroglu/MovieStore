using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieModel Model { get; set; }

        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var movie = _dbContext.Movies
                .SingleOrDefault(x => x.Title.Trim().ToLower() == Model.Title.Trim().ToLower());
            if(movie is not null)
                throw new InvalidOperationException("Film zaten mevcut");

            movie = _mapper.Map<Movie>(Model);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }
    

    public class CreateMovieModel{
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public double Price { get; set; }
    }
}