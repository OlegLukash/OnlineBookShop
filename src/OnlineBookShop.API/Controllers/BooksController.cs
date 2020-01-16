using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.API.Dtos.Books;
using OnlineBookShop.API.Infrastructure.Models;
using OnlineBookShop.API.Repositories.Interfaces;
using OnlineBookShop.Domain;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public BooksController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedBooks([FromQuery]PagedRequest pagedRequest)
        {
            var pagedBooksDto = await _repository.GetPagedData<Book, BookGridRowDto>(pagedRequest);
            return Ok(pagedBooksDto);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _repository.GetByIdWithInclude<Book>(id, book => book.Publisher);
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookForUpdateDto bookForUpdateDto)
        {
            var book = _mapper.Map<Book>(bookForUpdateDto);
            await _repository.Add<Book>(book);

            var bookDto = _mapper.Map<BookDto>(book);

            return CreatedAtAction(nameof(GetBook), new { id = bookDto.Id }, bookDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookForUpdateDto bookDto)
        {
            var book = await _repository.GetById<Book>(id);
            _mapper.Map(bookDto, book);
            await _repository.SaveAll();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _repository.Delete<Book>(id);
            return NoContent();
        }
    }
}