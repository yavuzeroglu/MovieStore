using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DBOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<ActorMovies> ActorMovies { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<DirectorMovie> DirectorMovies { get; set; }
        DbSet<FavoritesGenre> FavoritesGenres { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<PurchasedMovies> PurchasedMovies { get; set; }
        DbSet<Genre> Genres { get; set; }

        int SaveChanges();
    }
}