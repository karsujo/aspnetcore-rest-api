using AutoMapper;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books
{
    public class BookDtoProfile : Profile
    {
        public BookDtoProfile()
        {
            CreateMap<Book, BookDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
        .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Type));

            //TODO: Create Map Attributes
            CreateMap<BookForCreationDto, BookDto>();
        }
    }
}
