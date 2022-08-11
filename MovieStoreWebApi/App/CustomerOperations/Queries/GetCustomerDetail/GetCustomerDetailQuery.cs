using AutoMapper;
using MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomer;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomerDetail{
    public class GetCustomerDetailQuery {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetCustomerDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CustomerViewModel Handle(){
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == Id);
            if(customer is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı");
            
            CustomerViewModel vm = _mapper.Map<CustomerViewModel>(customer);

            return vm;
        }

    }
}