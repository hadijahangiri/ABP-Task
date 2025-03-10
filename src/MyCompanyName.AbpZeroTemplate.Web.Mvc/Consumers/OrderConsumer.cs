using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using MassTransit;
using MyCompanyName.AbpZeroTemplate.InboxPattern;
using MyCompanyName.AbpZeroTemplate.Shop.Orders;

namespace MyCompanyName.AbpZeroTemplate.Web.Consumers
{
    public class OrderConsumer : IConsumer<OrderCreatedEventData>
    {
        private readonly IRepository<InboxMessage, Guid> _repository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public OrderConsumer(IRepository<InboxMessage, Guid> repository, IUnitOfWorkManager unitOfWorkManager)
        {
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEventData> context)
        {
            var messageId = context.MessageId.Value;
            using var uow = _unitOfWorkManager.Begin();
            var existMessage = await _repository.FirstOrDefaultAsync(x => x.MessageId == messageId);
            if (existMessage == null)
            {
                var @event = context.Message;
                var inboxMessage = new InboxMessage(context.MessageId.Value, nameof(OrderCreatedEventData),
                    JsonSerializer.Serialize(@event));
                await _repository.InsertAsync(inboxMessage);
            }

            await uow.CompleteAsync();
        }
    }
}
