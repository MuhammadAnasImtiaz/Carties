using AutoMapper;
using Contracts;

namespace SearchService.RequestHelpers
{
    public class MappingProfies : Profile
    {
        public MappingProfies()
        {
            CreateMap<AuctionCreated, Item>();
            CreateMap<AuctionUpdated, Item>();
        }
    }
}
