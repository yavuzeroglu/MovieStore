using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.App.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.App.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreWebApi.App.CustomerOperations.Commands.UpdateCustomer;

using MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomer;
using MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomerDetail;
using MovieStoreWebApi.App.CustomerOperations.TokenOperations;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.TokenOperations.Model;

namespace MovieStoreWebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;


        public CustomerController(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetCustomer(){
            GetCustomerQuery query = new GetCustomerQuery(_dbContext,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerDetail(int id){
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_dbContext,_mapper);
            query.Id = id;

            var validator = new GetCustomerDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerViewModel newCustomer){
            CreateCustomerCommand command = new CreateCustomerCommand(_dbContext,_mapper);
            command.model = newCustomer;
            
            var validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerViewModel updateCustomer, int id){
            var command = new UpdateCustomerCommand(_dbContext);
            command.Id = id;
            command.Model = updateCustomer;

            var validator = new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id ){
            DeleteCustomerCommand command = new DeleteCustomerCommand(_dbContext);
            command.id = id;
            
            var validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login){
            
            CreateTokenCommand command = new CreateTokenCommand(_dbContext,_mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return Ok(token);
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token){
            RefreshTokenCommand command = new RefreshTokenCommand(_dbContext,_mapper,_configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken; 
        }
    }
}