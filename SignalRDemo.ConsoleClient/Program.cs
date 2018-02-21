using SignalRDemo.Notifications;
using System;
using System.Threading.Tasks;
using Unity;

namespace SignalRDemo.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string signalRAddress = "http://localhost:55839/notifications/";

            var container = new UnityContainer();

            var events = new NotificationEvents();
            container.RegisterInstance<INotificationEvents>(events);

            var handler = new SignalRHandler(container);
            Task.Run(async () => await handler.InitializeAsync(signalRAddress));

            events.SalesOrderCreated += (sender, e) =>
            {
                Console.WriteLine($"Order #{e.SalesOrder.Id} created for customer {e.SalesOrder.CustomerName}");
            };

            Console.ReadLine();

            Task.Run(async () => await handler.DisconnectAsync());
        }
    }
}
