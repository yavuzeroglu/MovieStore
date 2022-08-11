using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities{
    public class PurchasedMovies{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool movieStatus { get; set; }
        public DateTime purchasedTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}