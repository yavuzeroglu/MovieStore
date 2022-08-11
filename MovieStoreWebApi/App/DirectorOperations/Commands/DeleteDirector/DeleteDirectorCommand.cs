using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.DirectorOperations.Commands.DeleteDirector{
    public class DeleteDirectorCommand{
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }

        public DeleteDirectorCommand(IMovieStoreDbContext context){
            _dbContext = context;
        }

        public void Handle(){
            Director director = _dbContext.Directors.SingleOrDefault(x => x.Id == Id);
            if(director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");

            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();
        }
    }
}