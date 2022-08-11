using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                     new Genre { Name = "Comedy" },
                     new Genre { Name = "Action" },
                     new Genre { Name = "Sci-Fi" }
                );

                context.Actors.AddRange(
                    new Actor { Name = "Tom", Surname = "Cruise" },
                    new Actor { Name = "Morgan", Surname = "Freeman" },
                    new Actor { Name = "Scarlett", Surname = "Johansson" }
                );

                context.Directors.AddRange(
                    new Director { Name = "Quentin", Surname = "Tarantino" },
                    new Director { Name = "Martin", Surname = "Scorsese" }
                );

                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Mert",
                        Surname = "Uzerken",
                        Email = "mert@mail.com",
                        Password = "1234",

                    },
                    new Customer
                    {
                        Name = "Fatih",
                        Surname = "Eroglu",
                        Email = "fatih@mail.com",
                        Password = "1234"
                    }
                );

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "movie1",
                        GenreId = 1,
                        Price = 150,
                        PublishDate = new DateTime(2000, 01, 01)
                        
                    },
                    new Movie
                    {
                        Title = "movie2",
                        GenreId = 2,
                        Price = 200,
                        PublishDate = new DateTime(2000, 02, 02)
                        
                    },
                    new Movie
                    {
                        Title = "movie3",
                        GenreId = 2,
                        Price = 250,
                        PublishDate = new DateTime(2001, 03, 03)
                    },
                    new Movie
                    {
                        Title = "movie4",
                        GenreId = 3,
                        Price = 300,
                        PublishDate = new DateTime(2003, 04, 04)
                    }
                );

                context.ActorMovies.AddRange(
                    new ActorMovies { ActorId = 1, MovieId = 1 },
                    new ActorMovies { ActorId = 1, MovieId = 2 },
                    new ActorMovies { ActorId = 2, MovieId = 1 },
                    new ActorMovies { ActorId = 2, MovieId = 3 },
                    new ActorMovies { ActorId = 3, MovieId = 2 }
                );

                context.DirectorMovies.AddRange(
                    new DirectorMovie { DirectorId = 1, MovieId = 1 },
                    new DirectorMovie { DirectorId = 1, MovieId = 2 },
                    new DirectorMovie { DirectorId = 2, MovieId = 1 },
                    new DirectorMovie { DirectorId = 2, MovieId = 2 }
                );

                context.PurchasedMovies.AddRange(
                    new PurchasedMovies
                    {
                        movieStatus = true,
                        MovieId = 1,
                        CustomerId = 1,
                        purchasedTime = new DateTime(2022, 08, 03)
                    },
                    new PurchasedMovies
                    {
                        movieStatus = true,
                        MovieId = 2,
                        CustomerId = 1,
                        purchasedTime = new DateTime(2022, 08, 03)
                    },
                    new PurchasedMovies
                    {
                        movieStatus = true,
                        MovieId = 1,
                        CustomerId = 2,
                        purchasedTime = new DateTime(2021, 08, 03)
                    },
                    new PurchasedMovies
                    {
                        movieStatus = true,
                        MovieId = 3,
                        CustomerId = 2,
                        purchasedTime = new DateTime(2022, 08, 03)
                    },
                    new PurchasedMovies
                    {
                        movieStatus = true,
                        MovieId = 5,
                        CustomerId = 2,
                        purchasedTime = new DateTime(2020, 01, 03)
                    }
                );

                context.FavoritesGenres.AddRange(
                    new FavoritesGenre { CustomerId = 1, GenreId = 1 },
                    new FavoritesGenre { CustomerId = 1, GenreId = 2 },
                    new FavoritesGenre { CustomerId = 2, GenreId = 1 },
                    new FavoritesGenre { CustomerId = 2, GenreId = 2 }
                );
                context.SaveChanges();



            }
        }
    }
}