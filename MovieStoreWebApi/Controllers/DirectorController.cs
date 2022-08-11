using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieStoreWebApi.App.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.App.DirectorOperations.Commands.DeleteDirector;
using MovieStoreWebApi.App.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.App.DirectorOperations.Queries.GetDirector;
using MovieStoreWebApi.App.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
    

        public DirectorController(IMovieStoreDbContext context, IMapper mapper){
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirector(){
            GetDirectorQuery query = new GetDirectorQuery(_dbContext,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDirectorDetail(int id){
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_dbContext,_mapper);
            query.Id = id;
            
            var validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            
            GetDirectorViewModel result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorViewModel newDirector){
            CreateDirectorCommand command = new CreateDirectorCommand(_dbContext,_mapper);
            command.Model = newDirector;

            var validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector([FromBody] UpdateDirectorViewModel updateDirector, int id){
            UpdateDirectorCommand command = new UpdateDirectorCommand(_dbContext);
            command.Id = id;
            command.Model = updateDirector;

            var validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id){
            DeleteDirectorCommand command = new DeleteDirectorCommand(_dbContext);
            command.Id = id;
            
            var validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}