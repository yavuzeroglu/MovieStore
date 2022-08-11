using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.App.DirectorMovieOperations.Queries.GetDirectorMovie;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.DirectorMovieOperations.Queries.GetDetailDirectorMovie{
    public class GetDetailDirectorMovieQuery{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetDetailDirectorMovieQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetDirectorMovieViewModel Handle(){
            var directorMovie = _dbContext.Directors
            .Include(i => i.DirectorMovies).ThenInclude(i => i.Movie)
            .SingleOrDefault(x => x.Id == Id);
            if(directorMovie is null)
                throw new InvalidOperationException("Yönetmen Bulunamadı");
            
            GetDirectorMovieViewModel vm = _mapper.Map<GetDirectorMovieViewModel>(directorMovie);
            return vm;
        }

    }
}