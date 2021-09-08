using OnlineBookShop.Common.Dtos.Publishers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.Bll.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherListDto>> GetAllPublishers();
    }
}
