using System.ComponentModel.DataAnnotations;


namespace MovieStoreWebApi.Entities{
    public class Customer{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public ICollection<PurchasedMovies> PurchasedMovies { get; set; }
        public ICollection<FavoritesGenre> FavoritesGenres { get; set; }
        
    }
}