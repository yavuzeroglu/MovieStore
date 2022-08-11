using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.ActorMoviesOperations.Queries{
    
    public class GetActorMovieQuery{
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActorMovieViewModel> Handle()
        {
            var actorMovies = _context.Actors
                .Include(i => i.ActorMovies)
                .ThenInclude(t => t.Movie)
                .OrderBy(a => a.Id).ToList();
            List<GetActorMovieViewModel> vm = _mapper.Map<List<GetActorMovieViewModel>>(actorMovies);
            return vm;
        }
    } public class GetActorMovieViewModel{
        public int Id { get; set; }
        public string FullName { get; set; }
        public IReadOnlyList<string> Movies { get; set; }
    }
}