using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace WebApi.UnitTests.TestSetup{
    public static class DataGenerator{
        public static void AddData(this MovieStoreDbContext context){
            context.Movies.AddRange(
                new Movie{
                    Title = "test",
                    GenreId = 1,
                    Price = 100,
                    PublishDate = new DateTime(1996,02,19)
                },
                new Movie{
                    Title = "test2",
                    GenreId = 2,
                    Price = 200,
                    PublishDate = new DateTime(2002,02,20)
                },
                new Movie{
                    Title = "test3",
                    GenreId = 3,
                    Price = 300,
                    PublishDate = new DateTime(1994,03,06)
                },
                new Movie{
                    Title = "test4",
                    GenreId = 2,
                    Price = 350,
                    PublishDate = new DateTime(2001,03,22)
                }
            );

            context.Actors.AddRange(
                new Actor{ Name = "actor1", Surname = "actorSurname2" },
                new Actor{ Name = "actor2", Surname = "actorSurname2" },
                new Actor{ Name = "actor3", Surname = "actorSurname3"}
            );

            context.ActorMovies.AddRange(
                new ActorMovies{ ActorId = 1, MovieId = 1 },
                new ActorMovies{ ActorId = 1, MovieId = 2 },
                new ActorMovies{ ActorId = 2, MovieId = 1 },
                new ActorMovies{ ActorId = 2, MovieId = 2 },
                new ActorMovies{ ActorId = 3, MovieId = 1 }
            );

            context.Directors.AddRange(
                new Director{ Name = "Director1", Surname="DirectorSurname1" },
                new Director{ Name = "Director2", Surname="DirectorSurname2" },
                new Director{ Name = "Director3", Surname="DirectorSurname3" }
            );

            context.DirectorMovies.AddRange(
                new DirectorMovie{ DirectorId = 1, MovieId = 1},
                new DirectorMovie{ DirectorId = 1, MovieId = 2},
                new DirectorMovie{ DirectorId = 2, MovieId = 2},
                new DirectorMovie{ DirectorId = 3, MovieId = 1}
            );

            context.PurchasedMovies.AddRange(
                new PurchasedMovies{
                    movieStatus = true,
                    purchasedTime = new DateTime(2022,01,05),
                    CustomerId = 1,
                    MovieId = 1
                },
                new PurchasedMovies{
                    movieStatus = true,
                    purchasedTime = new DateTime(2022,02,05),
                    CustomerId = 1,
                    MovieId = 2
                },
                new PurchasedMovies{
                    movieStatus = true,
                    purchasedTime = new DateTime(2022,03,05),
                    CustomerId = 1,
                    MovieId = 3
                },
                new PurchasedMovies{
                    movieStatus = true,
                    purchasedTime = new DateTime(2022,01,10),
                    CustomerId = 2,
                    MovieId = 4
                },
                new PurchasedMovies{
                    movieStatus = false,
                    purchasedTime = new DateTime(2022,09,05),
                    CustomerId = 1,
                    MovieId = 1
                }
            );
            context.FavoritesGenres.AddRange(
                new FavoritesGenre{ CustomerId = 1, GenreId = 1 },
                new FavoritesGenre{ CustomerId = 1, GenreId = 2 },
                new FavoritesGenre{ CustomerId = 1, GenreId = 3 },
                new FavoritesGenre{ CustomerId = 2, GenreId = 4 }
                
            );
            context.Customers.AddRange(
                new Customer{
                    Name = "Customer1",
                    Surname = "CustomerSurname1",
                    Email = "custo1@mail.com",
                    Password = "11111"
                },
                new Customer{
                    Name = "Customer2",
                    Surname = "CustomerSurname2",
                    Email = "custo2@mail.com",
                    Password = "22222"
                },
                new Customer{
                    Name = "Customer3",
                    Surname = "CustomerSurname3",
                    Email = "custo3@mail.com",
                    Password = "33333"
                }
            );
        }
    }
}