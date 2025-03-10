using System;
using System.Text.Json;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using MyCompanyName.AbpZeroTemplate.InboxPattern;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders;

public class OrderBackgroundWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
{
    private const int CheckPeriodAsMilliseconds = 10 * 1000;
    private readonly IRepository<InboxMessage, Guid> _inboxRepository;
    private readonly IRepository<Order, Guid> _repository;
    public OrderBackgroundWorker(AbpTimer timer, IRepository<InboxMessage, Guid> inboxRepository, IRepository<Order, Guid> repository) : base(timer)
    {
        _inboxRepository = inboxRepository;
        _repository = repository;
        Timer.Period = CheckPeriodAsMilliseconds;
        Timer.RunOnStart = true;
    }

    protected override void DoWork()
    {
        using var uow = UnitOfWorkManager.Begin();
        var inboxMessages = _inboxRepository
            .GetAllList(x => x.IsProcessed == false
                                  && x.MessageType == nameof(OrderCreatedEventData));
        foreach (var inboxMessage in inboxMessages)
        {
            var @event = JsonSerializer.Deserialize<OrderCreatedEventData>(inboxMessage.Payload);
            var order = _repository.Get(@event.Id);
            order.Confirm();
            _repository.Update(order);

            inboxMessage.Processed();
            _inboxRepository.Update(inboxMessage);
        }
        uow.Complete();
    }
}