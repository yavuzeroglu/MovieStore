using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }

        public DeleteMovieCommand(IMovieStoreDbContext context){
            _dbContext = context;
        }

        public void Handle(){
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Id);
            if(movie is null)
                throw new InvalidOperationException("Silenecek film bulunamadı");
            
            
            movie.IsActive = false;
            
            _dbContext.SaveChanges();
        }
    }
}