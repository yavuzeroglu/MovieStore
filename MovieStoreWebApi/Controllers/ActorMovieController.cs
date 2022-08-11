using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.CreateActorMovie;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.DeleteActorMovie;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.UpdateActorMovie;
using MovieStoreWebApi.App.ActorMoviesOperations.Queries;
using MovieStoreWebApi.App.ActorMoviesOperations.Queries.GetActorMovieDetail;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class ActorMovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public ActorMovieController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActorMovie(){
            GetActorMovieQuery query = new GetActorMovieQuery(_dbContext,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

          
        [HttpGet("{id}")]
        public IActionResult GetActorMovieDetail(int id){
            var query = new GetActorMovieDetailQuery(_dbContext,_mapper);
            query.ActorMovieId = id;

            var validator = new GetActorMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);
            
            var result = query.Handle();
            return Ok(result);
            
        }
        
        //Hatalı düzenlenmeli
        [HttpPost]
        public IActionResult CreateActorMovie([FromBody] CreateActorMovieViewModel model){
            CreateActorMovieCommand command = new CreateActorMovieCommand(_dbContext,_mapper);
            command.model = model;

            var validator = new CreateActorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();

        }
        

        [HttpPut("{id}")]
        public IActionResult UpdateActorMovie([FromBody] UpdateActorMovieModel model, int id){
            UpdateActorMovieCommand command = new UpdateActorMovieCommand(_dbContext);
            command.model = model;
            command.Id = id;

            var validator = new UpdateActorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActorMovie(int id){
            DeleteActorMovieCommand command = new DeleteActorMovieCommand(_dbContext);
            command.Id = id;

            var validator = new DeleteActorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}