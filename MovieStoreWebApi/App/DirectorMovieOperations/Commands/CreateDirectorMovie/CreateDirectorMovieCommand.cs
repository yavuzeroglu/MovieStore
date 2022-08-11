using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Commands.CreateDirectorMovie
{
    public class CreateDirectorMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateDirectorMovieModel model;

        public CreateDirectorMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == model.DirectorId);
            var movies = _dbContext.Movies.SingleOrDefault(x => x.Id == model.MovieId);
            var directorMovie = _dbContext.DirectorMovies.SingleOrDefault(x => x.MovieId == model.MovieId);

            if (director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı");
            else if (directorMovie is not null)
                throw new InvalidOperationException("Bu filmin bir yönetmeni zaten mevcut");

            DirectorMovie result = _mapper.Map<DirectorMovie>(model);

            _dbContext.DirectorMovies.Add(result);
            _dbContext.SaveChanges();




        }
    }
    public class CreateDirectorMovieModel
    {
        public int DirectorId { get; set; }
        public int MovieId { get; set; }

    }

}