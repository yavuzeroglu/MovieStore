using FluentValidation;

namespace MovieStoreWebApi.App.DirectorOperations.Queries.GetDirectorDetail{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator(){
            RuleFor(comm => comm.Id).GreaterThan(0).NotEmpty().NotNull();
            
        }
    }
}