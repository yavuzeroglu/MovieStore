
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommand{
        private readonly IMovieStoreDbContext _dbContext;
        public CreateGenreViewModel Model {get; set;} 
        
        public CreateGenreCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
           
        }

        public void Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name.Trim().ToLower() == Model.Name.Trim().ToLower());
            if(genre is not null)
                throw new InvalidOperationException("Tür zaten kayıtlı");

            genre = new Genre();
            genre.Name = Model.Name;
            
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
        public class CreateGenreViewModel
        {
            public string Name { get; set; }
        }
    }
}