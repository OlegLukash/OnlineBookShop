using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.API.Repositories.Interfaces;
using OnlineBookShop.Domain;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepository;

        public BooksController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAll();
            return Ok(books);
        }
    }
}