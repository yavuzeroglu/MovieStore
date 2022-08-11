using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.App.FavoriteGenreOperations.Commands.CreateFavoriteGenre;
using MovieStoreWebApi.App.FavoriteGenreOperations.Commands.DeleteFavoriteGenre;
using MovieStoreWebApi.App.FavoriteGenreOperations.Commands.UpdateFavoriteGenre;
using MovieStoreWebApi.App.FavoriteGenreOperations.Queries.GetFavoriteGenre;
using MovieStoreWebApi.App.FavoriteGenreOperations.Queries.GetFavoriteGenreDetail;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class FavoriteGenreController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public FavoriteGenreController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFavoriteGenre(){
            GetFavoriteGenreQuery query = new GetFavoriteGenreQuery(_dbContext,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetFavoriteGenreById(int id)
        {
            var query = new GetFavoriteGenreDetailQuery(_dbContext,_mapper);
            query.Id = id;

            var validator = new GetFavoriteGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddFavoriteGenre([FromBody] CreateFavoriteGenreModel newFavoriteGenre){
            var command = new CreateFavoriteGenreCommand(_dbContext,_mapper);
            command.model = newFavoriteGenre;
            
            var validator = new CreateFavoriteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFavoriteGenre(int id,UpdateFavoriteGenreModel updateFavoriteGenre){
            var command = new UpdateFavoriteGenreCommand(_dbContext,_mapper);
            command.Id = id;
            command.Model = updateFavoriteGenre;

            var validator = new UpdateFavoriteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavoriteGenre(int id){
            var command = new DeleteFavoriteGenreCommand(_dbContext);
            command.Id = id;
            
            var validator = new DeleteFavoriteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}