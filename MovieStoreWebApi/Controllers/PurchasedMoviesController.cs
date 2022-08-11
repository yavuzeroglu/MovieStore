using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.CreatePurchasedMovies;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.DeletePurchasedMovies;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.UpdatePurchasedMovies;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Queries.GetPurchasedMovies;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Queries.GetPurchasedMoviesDetail;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class PurchasedMoviesController : ControllerBase
    {
        
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public PurchasedMoviesController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    
        [HttpGet]
        public IActionResult GetPurchasedMovies(){
            var query = new GetPurchasedMoviesQuery(_dbContext,_mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchasedMoviesDetail(int id){
            var query = new GetPurchasedMoviesDetailQuery(_dbContext,_mapper);
            query.Id = id;
            

            var validator = new GetPurchasedMoviesDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreatePurchasedMovies([FromBody] CreatePurchasedMoviesModel newPurchasedMovie){
            var command = new CreatePurchasedMoviesCommand(_dbContext,_mapper);
            command.model = newPurchasedMovie;
            
            var validator = new CreatePurchasedMoviesCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePurchasedMovies([FromBody] UpdatePurchasedMoviesModel updatePurchasedMovies, int id)
        {
            var command = new UpdatePurchasedMoviesCommand(_dbContext,_mapper);
            command.Id = id;
            command.model = updatePurchasedMovies;

            var validator = new UpdatePurchasedMoviesCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePurchasedMovies(int id){
            var command = new DeletePurchasedMoviesCommand(_dbContext);
            command.Id = id;

            var validator = new DeletePurchasedMoviesCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }

    
}