using AutoMapper;

using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.TokenOperations;
using MovieStoreWebApi.TokenOperations.Model;

namespace MovieStoreWebApi.App.CustomerOperations.TokenOperations{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        public readonly IMovieStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle(){
            var user = _dbContext.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if(user is not null){
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid Bir Refresh Token Bulunamadı");
            }
        }
    }
}