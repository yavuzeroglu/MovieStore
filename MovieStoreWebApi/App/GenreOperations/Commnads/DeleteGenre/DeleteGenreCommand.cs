using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.GenreOperations.Commands.DeleteGenre{
    public class DeleteGenreCommand{
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }


        public DeleteGenreCommand(IMovieStoreDbContext context){
            _dbContext = context;
        }

        public void Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Id);
            if(genre is null)
                throw new InvalidOperationException("Tür bulunamadı");
            
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();


        }
    }
}