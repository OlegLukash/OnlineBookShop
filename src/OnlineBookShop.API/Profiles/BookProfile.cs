using AutoMapper;
using OnlineBookShop.API.Dtos.Books;
using OnlineBookShop.Domain;

namespace OnlineBookShop.API.Profiles
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookForUpdateDto, Book>();
        }
    }
}
