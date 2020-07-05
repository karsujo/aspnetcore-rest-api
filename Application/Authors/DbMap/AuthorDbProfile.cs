using AutoMapper;
using OdysseyPublishers.Domain;

namespace Application.Authors
{
    public class AuthorDbProfile : Profile
    {
        public AuthorDbProfile()
        {
            CreateMap<AuthorDbEntity, Author>()
               .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.au_Id))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.au_fname))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.au_lname));

        }
    }
}
