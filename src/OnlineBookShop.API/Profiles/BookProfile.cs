using AutoMapper;
using OnlineBookShop.API.Dtos.Books;
using OnlineBookShop.Domain;

namespace OnlineBookShop.API.Profiles
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookGridRowDto>()
                .ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher.Name));
            CreateMap<Book, BookDto>()
                .ForMember(x => x.PublisherId, y => y.MapFrom(z => z.Publisher.Id)); ;
            CreateMap<BookForUpdateDto, Book>();
        }
    }
}
