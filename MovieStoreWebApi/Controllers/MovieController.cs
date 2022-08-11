using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.App.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.App.MovieOperations.Commands.DeleteMovie;
using MovieStoreWebApi.App.MovieOperations.Commands.UpdateMovie;
using MovieStoreWebApi.App.MovieOperations.Queries;
using MovieStoreWebApi.App.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovie(){
            GetMovieQuery query = new GetMovieQuery(_dbContext,_mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_dbContext,_mapper);
            query.Id = id;

            var validator = new GetMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie){
            CreateMovieCommand command = new CreateMovieCommand(_dbContext,_mapper);
            command.Model = newMovie;

            var validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie([FromBody] UpdateMovieModel updateMovie,int id){
            UpdateMovieCommand command = new UpdateMovieCommand(_dbContext);
            command.Model = updateMovie; 
            command.Id = id;

            var validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id){
            var command = new DeleteMovieCommand(_dbContext);
            command.Id = id;
            
            var validator = new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        
    }
}