using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.App.CustomerOperations.Commands.DeleteCustomer{
    public class DeleteCustomerCommand{
        private readonly IMovieStoreDbContext _dbContext;

        public int id { get; set; }

        public DeleteCustomerCommand(IMovieStoreDbContext context){
            _dbContext = context;
        }

        public void Handle(){
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == id);
            if(customer == null)
                throw new InvalidOperationException("Silmek istediğiniz kullanıcı bulunamadı.");
            
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();

        }
    }
}