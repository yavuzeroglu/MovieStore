using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Queries.GetActorMovieDetail{
    public class GetActorMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int ActorMovieId { get; set; }

        public GetActorMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetActorMovieViewModel Handle(){
            var actor = _context.Actors.Include(inc => inc.ActorMovies).ThenInclude(x => x.Movie).SingleOrDefault(x => x.Id == ActorMovieId);
            if(actor is null)
                throw new InvalidOperationException("Kayıt bulunamadı");

            GetActorMovieViewModel  vm = _mapper.Map<GetActorMovieViewModel>(actor);
            
            return vm;
        }
    }
}
