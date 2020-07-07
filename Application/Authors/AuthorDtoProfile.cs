using AutoMapper;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors
{
    public class AuthorDtoProfile :Profile
    {
        public AuthorDtoProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Zip));
        }
    }
}
