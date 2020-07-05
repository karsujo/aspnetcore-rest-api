using Application.DbEntities;
using AutoMapper;
using OdysseyPublishers.Domain;

namespace Application.DbMappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorEntity, Author>()
               .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.au_Id))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.au_fname))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.au_lname));

        }
    }
}
