using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomer{
    public class GetCustomerQuery{
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerQuery(IMovieStoreDbContext context, IMapper mapper){
            _dbContext = context;
            _mapper = mapper;
        }

        public List<CustomerViewModel> Handle(){
            List<Customer> customers = _dbContext.Customers.OrderBy(x => x.Id).ToList();
            List<CustomerViewModel> vm = _mapper.Map<List<CustomerViewModel>>(customers);

            return vm;
        }
        
    }

    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}