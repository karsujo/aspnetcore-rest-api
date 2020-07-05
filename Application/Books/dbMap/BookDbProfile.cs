using AutoMapper;
using OdysseyPublishers.Domain;

namespace Application.Books
{
    public class BookDbProfile : Profile
    {

        public BookDbProfile()
        {
            CreateMap<BookDbEntity, Book>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.title_id))
                .ForMember(dest => dest.PubId, opt => opt.MapFrom(src => src.pub_id))
                .ForMember(dest => dest.Sales, opt => opt.MapFrom(src => src.ytd_sales))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.pubdate));
        }
    }
}
