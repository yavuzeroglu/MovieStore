using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Commands.UpdateDirectorMovie{
    public class UpdateDirectorMovieCommand{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateDirectorMovieViewModel Model { get; set; }
        public UpdateDirectorMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var directorMovies = _dbContext.DirectorMovies.SingleOrDefault(x => x.Id == Id);
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == Model.DirectorId);
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Model.MovieId);
            if(directorMovies is null)
                throw new InvalidOperationException("Güncellenecek kayıt bulunamadı.");
            else if(director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı");
            else if(movie is null)
                throw new InvalidOperationException("Film bulunamadı");
            
            directorMovies.MovieId = Model.MovieId != default ? 
                Model.MovieId : directorMovies.MovieId;
            directorMovies.DirectorId = Model.DirectorId != default ?
                Model.DirectorId : directorMovies.MovieId;

                _dbContext.DirectorMovies.Update(directorMovies);
                _dbContext.SaveChanges();

        }
    }
    public class UpdateDirectorMovieViewModel{
        public int DirectorId { get; set; }
        public int MovieId { get; set; }
    }
}