using AutoMapper;
using OdysseyPublishers.Domain;

namespace Application.Books
{
    public class BookDtoMapperProfile : Profile
    {
        public BookDtoMapperProfile()
        {
            CreateMap<Book, BookDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
        .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Type));


            CreateMap<BookForCreationDto, BookDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));

            CreateMap<BookForUpdateDto, BookDto>();
            CreateMap<Book, BookForUpdateDto>();
        }
    }
}
