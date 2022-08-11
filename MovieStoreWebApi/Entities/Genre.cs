using System.ComponentModel.DataAnnotations;

namespace MovieStoreWebApi.Entities{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}