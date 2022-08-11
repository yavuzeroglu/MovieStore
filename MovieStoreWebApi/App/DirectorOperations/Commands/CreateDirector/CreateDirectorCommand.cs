using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateDirectorViewModel Model { get; set; }
        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault
                (x => x.Name.Trim().ToLower() == Model.Name.Trim().ToLower() && 
                x.Surname.Trim().ToLower() == Model.Surname.Trim().ToLower());
            if(director is not null)
                throw new InvalidOperationException("Yönetmen zaten kayıtlı");
            
            var newDirector = _mapper.Map<Director>(Model);

            _dbContext.Directors.Add(newDirector);
            _dbContext.SaveChanges();

        }
    }
    public class CreateDirectorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}