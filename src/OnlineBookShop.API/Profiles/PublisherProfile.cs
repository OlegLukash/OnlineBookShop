using AutoMapper;
using OnlineBookShop.API.Dtos.Publishers;
using OnlineBookShop.Domain;

namespace OnlineBookShop.API.Profiles
{
    public class PublisherProfile: Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>();
        }
    }
}
