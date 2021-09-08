using OnlineBookShop.Common.Dtos.Books;
using OnlineBookShop.Common.Models.PagedRequest;
using System.Threading.Tasks;

namespace OnlineBookShop.Bll.Interfaces
{
    public interface IBookService
    {
        Task<PaginatedResult<BookListDto>> GetPagedBooks(PagedRequest pagedRequest);

        Task<BookDto> GetBook(int id);

        Task<BookDto> CreateBook(BookForUpdateDto bookForUpdateDto);

        Task UpdateBook(int id, BookForUpdateDto bookDto);

        Task DeleteBook(int id);
    }
}
