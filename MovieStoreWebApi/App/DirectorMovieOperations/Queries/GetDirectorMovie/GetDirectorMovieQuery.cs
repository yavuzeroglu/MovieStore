using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Queries.GetDirectorMovie{
    public class GetDirectorMovieQuery{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorMovieQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetDirectorMovieViewModel> Handle(){
            var directorMoviesList  = _dbContext.Directors
                .Include(x => x.DirectorMovies)
                .ThenInclude(y => y.Movie)
                .OrderBy(x => x.Id ).ToList();
            List<GetDirectorMovieViewModel> vm = _mapper.Map<List<GetDirectorMovieViewModel>>(directorMoviesList);

            return vm;

            
        }
    }
    public class GetDirectorMovieViewModel{
        public string FullName { get; set; }
        public IReadOnlyCollection<string> Movies { get; set; }
    }
}