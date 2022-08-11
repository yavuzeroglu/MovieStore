using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre;
using MovieStoreWebApi.App.GenreOperations.Commands.DeleteGenre;
using MovieStoreWebApi.App.GenreOperations.Commands.UpdateGenre;
using MovieStoreWebApi.App.GenreOperations.Queries.GetGenre;
using MovieStoreWebApi.App.GenreOperations.Queries.GetGenreDetail;
using MovieStoreWebApi.DBOperations;
using static MovieStoreWebApi.App.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace MovieStoreWebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public GenreController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenre(){
            GetGenreQuery query = new GetGenreQuery(_dbContext,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id){
            GetGenreDetailQuery query = new GetGenreDetailQuery(_dbContext,_mapper);
            query.Id = id;

            var validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_dbContext);
            command.Model = newGenre;

            var validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id){
            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            command.Id = id;

            var validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);


            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, CreateGenreViewModel model){
            UpdateGenreCommand command = new UpdateGenreCommand(_dbContext);
            command.Id = id;
            command.Model = model;

            var validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}