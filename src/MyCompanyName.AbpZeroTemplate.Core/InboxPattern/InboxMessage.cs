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
        public string MessageId { get; private set; }
        public string MessageType { get; private set; }
        public string Payload { get; private set; }
        public bool IsProcessed { get; private set; }
        public DateTime ReceivedAt { get; private set; }

        private InboxMessage() { }
        public InboxMessage(string messageId, string payload)
        {
            MessageId = messageId;
            Payload = payload;
            IsProcessed = false;
            ReceivedAt = DateTime.Now;
        }

    }
}
