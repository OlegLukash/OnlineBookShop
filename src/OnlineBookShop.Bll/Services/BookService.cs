using AutoMapper;
using OnlineBookShop.Bll.Interfaces;
using OnlineBookShop.Common.Dtos.Books;
using OnlineBookShop.Common.Models.PagedRequest;
using OnlineBookShop.Dal.Interfaces;
using OnlineBookShop.Domain;
using System.Threading.Tasks;

namespace OnlineBookShop.Bll.Services
{
    public class BookService: IBookService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<BookListDto>> GetPagedBooks(PagedRequest pagedRequest)
        {
            var pagedBooksDto = await _repository.GetPagedData<Book, BookListDto>(pagedRequest);
            return pagedBooksDto;
        }

        public async Task<BookDto> GetBook(int id)
        {
            var book = await _repository.GetByIdWithInclude<Book>(id, book => book.Publisher);
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public async Task<BookDto> CreateBook(BookForUpdateDto bookForUpdateDto)
        {
            var book = _mapper.Map<Book>(bookForUpdateDto);
            _repository.Add(book);
            await _repository.SaveChangesAsync();

            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public async Task UpdateBook(int id, BookForUpdateDto bookDto)
        {
            var book = await _repository.GetById<Book>(id);
            _mapper.Map(bookDto, book);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            await _repository.Delete<Book>(id);
            await _repository.SaveChangesAsync();
        }
    }
}
