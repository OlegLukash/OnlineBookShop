using AutoMapper;
using OnlineBookShop.Common.Dtos.Books;
using OnlineBookShop.Domain;

namespace OnlineBookShop.Bll.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookListDto>()
                .ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher.Name));
            CreateMap<Book, BookDto>()
                .ForMember(x => x.PublisherId, y => y.MapFrom(z => z.Publisher.Id));
            CreateMap<BookForUpdateDto, Book>();
        }
    }
}
