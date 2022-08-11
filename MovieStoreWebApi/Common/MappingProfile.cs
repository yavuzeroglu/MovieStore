using AutoMapper;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands;
using MovieStoreWebApi.App.ActorMoviesOperations.Commands.CreateActorMovie;
using MovieStoreWebApi.App.ActorMoviesOperations.Queries;
using MovieStoreWebApi.App.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.App.ActorOperations.Queries.GetActor;
using MovieStoreWebApi.App.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.App.CustomerOperations.Queries.GetCustomer;
using MovieStoreWebApi.App.DirectorMovieOperations.Commands.CreateDirectorMovie;
using MovieStoreWebApi.App.DirectorMovieOperations.Queries.GetDirectorMovie;
using MovieStoreWebApi.App.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.App.DirectorOperations.Queries.GetDirector;
using MovieStoreWebApi.App.FavoriteGenreOperations.Commands.UpdateFavoriteGenre;
using MovieStoreWebApi.App.FavoriteGenreOperations.Queries.GetFavoriteGenre;
using MovieStoreWebApi.App.GenreOperations.Queries.GetGenre;
using MovieStoreWebApi.App.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.App.MovieOperations.Queries;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Commands.CreatePurchasedMovies;
using MovieStoreWebApi.App.PurchasedMoviesOperations.Queries.GetPurchasedMovies;
using MovieStoreWebApi.Entities;


namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Actor Maps
            CreateMap<Actor, GetActorViewModel>();
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, GetActorMovieViewModel>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname))
                .ForMember(d => d.Movies, opt => opt.MapFrom(opt => opt.ActorMovies.Select(src => src.Movie.Title)));


            // ActorMovie Maps
            CreateMap<CreateActorMovieViewModel, ActorMovies>();


            // Customer Maps
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CreateCustomerViewModel, Customer>();

            // Director Maps
            CreateMap<Director, GetDirectorViewModel>();
            CreateMap<CreateDirectorViewModel, Director>();

            // DirectorMovie Maps
            CreateMap<Director,GetDirectorMovieViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(a => a.Name+ " "+ a.Surname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(a => a.DirectorMovies.Select(b => b.Movie.Title)));
            CreateMap<CreateDirectorMovieModel, DirectorMovie>();
            
            // FavoritesGenre Maps
            CreateMap<Customer,GetFavoriteGenreViewModel>()
                .ForMember(d => d.Customer, opt => opt.MapFrom(x => x.Name +" "+x.Surname))
                .ForMember(d => d.Genres, opt => opt.MapFrom(x => x.FavoritesGenres.Select(x => x.Genre.Name)));
            
            //CreateMap<CreateFavoriteGenreModel, FavoritesGenre>();
            CreateMap<UpdateFavoriteGenreModel, FavoritesGenre>();

            
            // Genre Maps
            CreateMap<Genre, GetGenreViewModel>();

            // Movie Maps
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.Actors, o => o.MapFrom(x => x.Actors.Select(x => x.Actor.Name +" "+ x.Actor.Surname)))

                .ForMember(dest => dest.Director, o => o.MapFrom(x => x.DirectorMovies.Select(s => s.Director.Name+" "+s.Director.Surname)))

                .ForMember(dest => dest.Genre, o => o.MapFrom(x => x.Genre.Name))
                .ForMember(dest => dest.PublishDate, o => o.MapFrom(src => src.PublishDate.ToShortDateString()));

            CreateMap<CreateMovieModel, Movie>();


            // PurchasedMovies Maps ...
            CreateMap<Customer, GetPurchasedMoviesModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname))
                
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(x => x.PurchasedMovies.Select(src => src.Movie.Title)))

                .ForMember(dest => dest.Price, o => o.MapFrom(x => x.PurchasedMovies.Select(s => s.Movie.Price)))

                .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(x => x.PurchasedMovies.Select(s => s.purchasedTime)));
            
            CreateMap<CreatePurchasedMoviesModel, PurchasedMovies>();

        }
    }
}