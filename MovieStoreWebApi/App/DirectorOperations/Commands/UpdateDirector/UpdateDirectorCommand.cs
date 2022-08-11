using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.DirectorOperations.Commands.UpdateDirector{
    public class UpdateDirectorCommand{
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateDirectorViewModel Model;
        public int Id { get; set; }

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            Director director = _dbContext.Directors.SingleOrDefault(x => x.Id == Id);
            if(director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı");
            
            director.Name = Model.Name != default ? Model.Name : director.Name;
            director.Surname = Model.Surname != default ? Model.Surname : director.Surname;
            
            _dbContext.SaveChanges();
        }

    }
    public class UpdateDirectorViewModel{
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}