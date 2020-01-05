﻿using AutoMapper;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _repository.GetById<Book>(id);
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