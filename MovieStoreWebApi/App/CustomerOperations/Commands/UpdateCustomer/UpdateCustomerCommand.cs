
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.CustomerOperations.Commands.UpdateCustomer{
    public class UpdateCustomerCommand{
        private readonly IMovieStoreDbContext _dbContext;
        
        public UpdateCustomerViewModel Model { get; set; }

        public int Id { get; set; }
        public UpdateCustomerCommand(IMovieStoreDbContext dbContext){
            _dbContext = dbContext;
            
        }

        public void Handle(){
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı.");
            
            customer.Name = Model.Name != default ? 
                Model.Name : customer.Name;
            customer.Surname = Model.Surname != default ? 
                Model.Surname : customer.Surname;
            customer.Email = Model.Email != default ? 
                Model.Email : customer.Email;
            customer.Password = Model.Password != default ? 
                Model.Password : customer.Password;

            _dbContext.SaveChanges();


        }
    }
    public class UpdateCustomerViewModel{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}