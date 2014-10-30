using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Messages;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Logging;

namespace NimbusB
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is how you tell Nimbus where to find all your message types and handlers.
            var typeProvider = new AssemblyScanningTypeProvider(Assembly.GetExecutingAssembly(), typeof(MessageA).Assembly);


            var bus = new BusBuilder().Configure()
                                        .WithNames("B", Environment.MachineName)
                                        .WithConnectionString(Const.ConnectionString)
                                        .WithTypesFrom(typeProvider)
                                        .WithDefaultTimeout(TimeSpan.FromSeconds(10))
                                        .WithSubscriptionAutoDeleteOnIdle(TimeSpan.FromMinutes(5))
                                        .WithMaxSubscriptionDefaultMessageTimeToLive(TimeSpan.FromSeconds(2))
                                        .WithMaxDeliveryAttempts(1)
                                        .WithSubscriptionAutoDeleteOnIdle(TimeSpan.FromMinutes(5))
                                        .WithEnableDeadLetteringOnMessageExpiration(false)
                                        .Build();
            bus.Start();
            Console.WriteLine("Started B");
            while (true)
            {
                bus.Publish(new MessageB { Timestamp = DateTime.Now }).Wait();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
