using System;
using Nimbus.MessageContracts;

namespace Messages
{
    [Serializable]
    public class MessageA : IBusEvent
    {
        public DateTime Timestamp { get; set; }
    }
}