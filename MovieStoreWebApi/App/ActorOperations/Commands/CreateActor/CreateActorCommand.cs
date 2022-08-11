using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public CreateActorModel Model { get; set; }
        

        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(a => a.Name == Model.Name && a.Surname == Model.Surname);
            if (actor is not null)
                throw new InvalidOperationException("Oyuncu zaten mevcut");

            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();

        }


    }
    public class CreateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}