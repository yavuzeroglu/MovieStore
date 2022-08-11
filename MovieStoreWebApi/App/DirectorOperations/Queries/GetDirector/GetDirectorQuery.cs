using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.DirectorOperations.Queries.GetDirector
{
    public class GetDirectorQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetDirectorViewModel> Handle()
        {
            var directorList = _dbContext.Directors.OrderBy(x => x.Id).ToList<Director>();
            List<GetDirectorViewModel> vm = _mapper.Map<List<GetDirectorViewModel>>(directorList);

            return vm;

        }
    }
    public class GetDirectorViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }

}