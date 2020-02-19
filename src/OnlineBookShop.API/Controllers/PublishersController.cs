using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.API.Dtos.Publishers;
using OnlineBookShop.API.Repositories.Interfaces;
using OnlineBookShop.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PublishersController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publisherList = await _repository.GetAll<Publisher>();
            var publisherDtoList = _mapper.Map<List<PublisherDto>>(publisherList);
            return Ok(publisherDtoList);
        }
    }
}