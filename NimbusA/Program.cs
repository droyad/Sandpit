using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Messages;
using Nimbus.Configuration;
using Nimbus.Infrastructure;

namespace NimbusA
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // This is how you tell Nimbus where to find all your message types and handlers.
            var typeProvider = new AssemblyScanningTypeProvider(Assembly.GetExecutingAssembly(), typeof(MessageA).Assembly);


            var bus = new BusBuilder().Configure()
                                        .WithNames("A", Environment.MachineName)
                                        .WithConnectionString(Const.ConnectionString)
                                        .WithTypesFrom(typeProvider)
                                        .WithDefaultTimeout(TimeSpan.FromSeconds(10))
                                        .Build();
            bus.Start();

            Console.WriteLine("Started A");
            while (true)
            {
                bus.Publish(new MessageA {Timestamp = DateTime.Now}).Wait();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
