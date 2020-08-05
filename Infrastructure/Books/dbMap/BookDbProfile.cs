using AutoMapper;
using OdysseyPublishers.Domain;

namespace Infrastructure.Books
{
    public class BookDbProfile : Profile
    {

        public BookDbProfile()
        {
            CreateMap<BookDbEntity, Book>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.book_id))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.pubdate))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.au_id));
        }
    }
}
