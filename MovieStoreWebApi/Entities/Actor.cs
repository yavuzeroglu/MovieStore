using System.ComponentModel.DataAnnotations;


namespace MovieStoreWebApi.Entities
{
    public class Actor{
        [Key]
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<ActorMovies> ActorMovies { get; set; }

    }
}