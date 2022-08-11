using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Commands.DeleteActorMovie
{
    public class DeleteActorMovieCommand
    {
        private IMovieStoreDbContext _dbContext;
        public int Id { get; set; }
        public DeleteActorMovieCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var actorMovies = _dbContext.ActorMovies.SingleOrDefault(x => x.Id == Id);
            if (actorMovies is null)
                throw new InvalidOperationException("Kayıt bulunamadı");

            _dbContext.ActorMovies.Remove(actorMovies);
            _dbContext.SaveChanges();
        }
    }
}