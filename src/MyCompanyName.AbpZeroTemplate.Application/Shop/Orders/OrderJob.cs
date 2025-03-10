using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using MyCompanyName.AbpZeroTemplate.InboxPattern;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders
{
    public class OrderJob : AsyncBackgroundJob<UserIdentifier>, ITransientDependency
    {
        private readonly IRepository<Order, Guid> _repository;
        private readonly IRepository<InboxMessage, Guid> _inboxRepository;

        public OrderJob(IRepository<Order, Guid> repository, IRepository<InboxMessage, Guid> inboxRepository)
        {
            _repository = repository;
            _inboxRepository = inboxRepository;
        }

        public override async Task ExecuteAsync(UserIdentifier args)
        {
            using var uow = UnitOfWorkManager.Begin();
            var inboxMessages = await _inboxRepository
                .GetAllListAsync(x => x.IsProcessed == false
                                      && x.MessageType == nameof(OrderCreatedEventData));
            foreach (var inboxMessage in inboxMessages)
            {
                var @event = JsonSerializer.Deserialize<OrderCreatedEventData>(inboxMessage.Payload);
                var order = await _repository.GetAsync(@event.Id);
                order.Confirm();
                await _repository.UpdateAsync(order);

                inboxMessage.Processed();
                await _inboxRepository.UpdateAsync(inboxMessage);
            }
            await uow.CompleteAsync();

        }
    }
}
