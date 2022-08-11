using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.ActorOperations.Commands.DeleteActor{
    public class DeleteActorCommand{
        private readonly IMovieStoreDbContext _dbContext;
        public int ActorId { get; set; }

        public DeleteActorCommand(IMovieStoreDbContext context){
            _dbContext = context;
        }

        public void Handle(){
            var actor = _dbContext.Actors.SingleOrDefault(act => act.Id == ActorId);
            if(actor is null)
                throw new InvalidOperationException("Silinecek Aktör bulunamadı");


            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
            
        }
    }
}