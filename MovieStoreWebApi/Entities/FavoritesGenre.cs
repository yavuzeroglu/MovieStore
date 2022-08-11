using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApi.Entities
{
    public class FavoritesGenre
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int GenreId { get; set;}
        public Genre Genre { get; set; }


    }
}