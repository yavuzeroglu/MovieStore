using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if(actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı");

            actor.Name= 
                (Model.Name != default) ? Model.Name : actor.Name;
            actor.Surname= 
                (Model.Surname != default) ? Model.Surname : actor.Surname;
            
            _dbContext.SaveChanges();
            
        }
    }

    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
    }
}