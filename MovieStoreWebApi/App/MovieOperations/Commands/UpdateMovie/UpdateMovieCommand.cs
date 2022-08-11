using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.MovieOperations.Commands.UpdateMovie{
    public class UpdateMovieCommand{
        private readonly IMovieStoreDbContext _dbContext;
        public int Id { get; set; }
        public UpdateMovieModel Model { get; set; }
        public UpdateMovieCommand(IMovieStoreDbContext context){
            _dbContext = context;
           
        }

        public void Handle(){
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Id);
            if(movie is null)
                throw new InvalidOperationException("Film bulunamadı");
            
            movie.Title = Model.Title != default ?
                Model.Title : movie.Title;
            movie.GenreId = Model.GenreId != default ?
                Model.GenreId : movie.GenreId;
            movie.Price = Model.Price != default ?
                Model.Price : movie.Price;
            movie.PublishDate = Model.PublishDate != default ?
                Model.PublishDate : movie.PublishDate;

            _dbContext.SaveChanges();
        }
    } public class UpdateMovieModel{
        public string Title { get; set; }
        public int GenreId { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}