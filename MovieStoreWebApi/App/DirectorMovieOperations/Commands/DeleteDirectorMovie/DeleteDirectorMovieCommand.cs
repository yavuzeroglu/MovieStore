using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Commands.DeleteDirectorMovie{
    public class DeleteDirectorMovieCommand{
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }

        public DeleteDirectorMovieCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        
        public void Handle(){
            var directorMovie = _dbContext.DirectorMovies.SingleOrDefault(x => x.Id == Id);
            if(directorMovie is null)
                throw new InvalidOperationException("Kayıt bulunamadı");
            
            _dbContext.DirectorMovies.Remove(directorMovie);
            _dbContext.SaveChanges();
        }
    }
}