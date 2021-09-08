using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Bll.Interfaces;
using OnlineBookShop.Common.Dtos.Books;
using OnlineBookShop.Common.Models.PagedRequest;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Controllers
{
    [Route("api/books")]
    public class BooksController : AppBaseController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<BookListDto>> GetPagedBooks([FromBody]PagedRequest pagedRequest)
        {
            var pagedBooksDto = await _bookService.GetPagedBooks(pagedRequest);
            return pagedBooksDto;  
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetBook(int id)
        {
            var bookDto = await _bookService.GetBook(id);
            return bookDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookForUpdateDto bookForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookDto = await _bookService.CreateBook(bookForUpdateDto);

            return CreatedAtAction(nameof(GetBook), new { id = bookDto.Id }, bookDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookForUpdateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bookService.UpdateBook(id, bookDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
        }
    }
}