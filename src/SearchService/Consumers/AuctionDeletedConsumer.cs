using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService.Consumers
{
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        private readonly IMapper _mapper;

        public AuctionDeletedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            Console.WriteLine("--> Consuming auction delted: " + context.Message.Id);

            var item = _mapper.Map<Item>(context.Message);

            var result = await DB.DeleteAsync<Item>("ID");

            if (!result.IsAcknowledged)
                throw new MessageException(typeof(AuctionUpdated), "Problem deleting mongodb");
        }
    }
}
