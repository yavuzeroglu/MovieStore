using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DBOperations{
    public class MovieStoreDbContext : DbContext , IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovies> ActorMovies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<DirectorMovie> DirectorMovies { get; set; }
        public DbSet<FavoritesGenre> FavoritesGenres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<PurchasedMovies> PurchasedMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}