using System;
using System.Threading.Tasks;
using Messages;
using Nimbus.Handlers;

namespace NimbusA
{
    public class MessageBHandler : IHandleMulticastEvent<MessageB>
    {
        public Task Handle(MessageB busEvent)
        {
            return Task.Run(() => Console.WriteLine("B " + busEvent.Timestamp.ToString("mm:ss")));
        }
    }
}