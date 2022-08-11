
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Commands.UpdateActorMovie{
    public class UpdateActorMovieCommand{
        
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }
        public UpdateActorMovieModel model { get; set; }

        public UpdateActorMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var actor  = _dbContext.Actors.SingleOrDefault(x => x.Id == model.ActorId);
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == model.MovieId);
            var actorMovies = _dbContext.ActorMovies.SingleOrDefault(x => x.Id == Id);

            if ( actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı");
            else if (movie is null)
                throw new InvalidOperationException("Film bulunamadı");
            else if (actorMovies is null)
                throw new InvalidOperationException("Kayıta ait veri bulunamadı");

            actorMovies.ActorId = 
                (model.ActorId == default) ? actorMovies.ActorId : model.ActorId;
            actorMovies.MovieId = 
                (model.MovieId == default) ? actorMovies.MovieId : model.MovieId;
            
            
            _dbContext.SaveChanges();


        }

    }
    public class UpdateActorMovieModel{
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}