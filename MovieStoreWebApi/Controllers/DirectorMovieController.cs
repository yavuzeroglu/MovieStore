using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.App.DirectorMovieOperations.Commands.CreateDirectorMovie;
using MovieStoreWebApi.App.DirectorMovieOperations.Commands.DeleteDirectorMovie;
using MovieStoreWebApi.App.DirectorMovieOperations.Commands.UpdateDirectorMovie;
using MovieStoreWebApi.App.DirectorMovieOperations.Queries.GetDetailDirectorMovie;
using MovieStoreWebApi.App.DirectorMovieOperations.Queries.GetDirectorMovie;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorMoviesController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public DirectorMoviesController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectorMovie()
        {
            GetDirectorMovieQuery query = new GetDirectorMovieQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailDirectorMovie(int id)
        {
            GetDetailDirectorMovieQuery query = new GetDetailDirectorMovieQuery(_dbContext, _mapper);
            query.Id = id;
            
            var validator = new GetDirectorMovieDetailValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirectorMovie
            ([FromBody] CreateDirectorMovieModel newDirectorMovie)
        {
            var command = new CreateDirectorMovieCommand(_dbContext, _mapper);
            command.model = newDirectorMovie;

            var validator = new CreateDirectorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirectorMovie(UpdateDirectorMovieViewModel updatedDirectorMovie, int id){
            UpdateDirectorMovieCommand command = new UpdateDirectorMovieCommand(_dbContext,_mapper);
            command.Id = id;
            command.Model = updatedDirectorMovie;

            var validator = new UpdateDirectorMovieCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirectorMovie(int id){
            DeleteDirectorMovieCommand command = new DeleteDirectorMovieCommand(_dbContext);
            command.Id = id;

            var validator = new DeleteDirectorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}