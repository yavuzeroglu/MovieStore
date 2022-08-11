using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.ActorOperations.Queries.GetActor{
    public class GetActorQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        public List<GetActorViewModel> Handle(){
            List<Actor> actorList = _context.Actors.OrderBy(a => a.Id).ToList<Actor>();
            List<GetActorViewModel> vm = _mapper.Map<List<GetActorViewModel>>(actorList);
            return vm;
            
            
        }
    }
    public class GetActorViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        

    }
}