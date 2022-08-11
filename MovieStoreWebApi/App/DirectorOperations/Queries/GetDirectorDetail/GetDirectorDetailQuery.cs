using AutoMapper;
using MovieStoreWebApi.App.DirectorOperations.Queries.GetDirector;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.DirectorOperations.Queries.GetDirectorDetail{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public GetDirectorViewModel Handle(){
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == Id);
            if(director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");
            
            GetDirectorViewModel vm = _mapper.Map<GetDirectorViewModel>(director);

            return vm;
        }

    }
    


}