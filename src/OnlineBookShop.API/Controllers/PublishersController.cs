using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Bll.Interfaces;
using OnlineBookShop.Common.Dtos.Publishers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Controllers
{
    [Route("api/publishers")]
    public class PublishersController : AppBaseController
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IEnumerable<PublisherListDto>> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublishers();
            return publishers;
        }
    }
}