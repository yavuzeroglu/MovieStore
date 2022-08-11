using AutoMapper;
using MovieStoreWebApi.App.ActorOperations.Queries.GetActor;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.ActorOperations.Queries.GetActorDetail{
    public class GetActorDetailQuery{
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper){
            _dbContext = context;
            _mapper = mapper;
        }

        public GetActorViewModel Handle(){
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if(actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı");

            GetActorViewModel actorDetailViewModel = _mapper.Map<GetActorViewModel>(actor);

            return actorDetailViewModel;
        }
    }
    
}