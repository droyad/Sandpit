using System;
using System.Threading.Tasks;
using Messages;
using Nimbus.Handlers;

namespace NimbusB
{
    public class MessageAHandler : IHandleMulticastEvent<MessageA>
    {
        public Task Handle(MessageA busEvent)
        {
            return Task.Run(() => Console.WriteLine("A " + busEvent.Timestamp.ToString("mm:ss")));
        }
    }
}