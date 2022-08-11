using MovieStoreWebApi.DBOperations;
using static MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace MovieStoreWebApi.App.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }
        public CreateGenreViewModel Model { get; set; }
        public UpdateGenreCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Id);
            if (genre is null)
                throw new InvalidOperationException("Tür bulunamadı");

            genre.Name = (string.IsNullOrEmpty(Model.Name.Trim())) ? genre.Name : Model.Name;
            _dbContext.SaveChanges();
        }
    }

}