using AutoMapper;
using OnlineBookShop.Bll.Interfaces;
using OnlineBookShop.Common.Dtos.Publishers;
using OnlineBookShop.Dal.Interfaces;
using OnlineBookShop.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.Bll.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PublisherService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublisherListDto>> GetAllPublishers()
        {
            var publisherList = await _repository.GetAll<Publisher>();
            var publisherDtoList = _mapper.Map<List<PublisherListDto>>(publisherList);
            return publisherDtoList;
        }
    }
}
