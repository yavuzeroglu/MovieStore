using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApi.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<ActorMovies> Actors { get; set; }
        public virtual ICollection<DirectorMovie> DirectorMovies { get; set; }

    }

}