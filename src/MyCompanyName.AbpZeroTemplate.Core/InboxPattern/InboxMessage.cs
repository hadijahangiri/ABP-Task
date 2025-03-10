using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MyCompanyName.AbpZeroTemplate.InboxPattern
{
    public class InboxMessage : AggregateRoot<Guid>
    {
        //TODO: set tenant id for multi tenancy
        public Guid MessageId { get; private set; }
        public string MessageType { get; private set; }
        public string Payload { get; private set; }
        public bool IsProcessed { get; private set; }
        public DateTime ReceivedAt { get; private set; }

        private InboxMessage() { }
        public InboxMessage(Guid messageId, string messageType, string payload)
        {
            MessageId = messageId;
            MessageType = messageType;
            Payload = payload;
            IsProcessed = false;
            ReceivedAt = DateTime.Now;
        }

        public void Processed()
        {
            IsProcessed = true;
        }

    }
}
