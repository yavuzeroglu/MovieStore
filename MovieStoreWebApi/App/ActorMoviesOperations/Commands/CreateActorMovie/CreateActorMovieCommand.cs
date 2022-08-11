using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Commands.CreateActorMovie
{
    public class CreateActorMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActorMovieViewModel model;

        public CreateActorMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == model.ActorId);
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == model.MovieId);
            var actorMovies = _dbContext.ActorMovies.SingleOrDefault(x => x.ActorId == model.ActorId && x.MovieId == model.MovieId);

            if(actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı");
            else if(movie is null)
                throw new InvalidOperationException("Film bulunamadı");
            else if(actorMovies is not null)
                throw new InvalidOperationException("Oyuncu daha önce bu filme zaten eklenmiş");
            
            var result = _mapper.Map<ActorMovies>(model);

            _dbContext.ActorMovies.Add(result);
            _dbContext.SaveChanges();
        }
    }

    public class CreateActorMovieViewModel
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}