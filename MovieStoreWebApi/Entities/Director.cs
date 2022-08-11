using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApi.Entities
{
    public class Director{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<DirectorMovie> DirectorMovies { get; set; }
    }
}