using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.App.CustomerOperations.Commands.CreateCustomer{
    public class CreateCustomerCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateCustomerViewModel model { get; set;}
        public CreateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Email.ToLower() == model.Email.ToLower());
            if (customer is not null){
                throw new InvalidOperationException("Mail Adresine kayıtlı kullanıcı zaten mevcut");}
            
            var result = _mapper.Map<Customer>(model);

            _dbContext.Customers.Add(result);
            _dbContext.SaveChanges();
            

        }


    } 
    public class CreateCustomerViewModel{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


}