using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.API.Dtos.Books;
using OnlineBookShop.API.Repositories.Interfaces;
using OnlineBookShop.Domain;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _repository.GetAll<Book>();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Ok(bookDtos);
        }
    }
}