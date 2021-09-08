using AutoMapper;
using OnlineBookShop.Common.Dtos.Publishers;
using OnlineBookShop.Domain;

namespace OnlineBookShop.Bll.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherListDto>();
        }
    }
}
