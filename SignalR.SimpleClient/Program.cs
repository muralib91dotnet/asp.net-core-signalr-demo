using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR.SimpleClient
{
    class Program
    {

        static async Task Main(string[] args)
        {
            HubConnection connection;

            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/eventHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<string>("SendNoticeEventToClient", (message) =>
            {
                Console.WriteLine($"SignalR event received. Event details: {message}");
            });

            await connection.StartAsync();

            Console.ReadLine();
        }
    }
}
