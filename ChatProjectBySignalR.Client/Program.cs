using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace ChatProjectBySignalR.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder().WithUrl("http://localhost:19715/chat")
                                                       .WithConsoleLogger()
                                                       .Build();
            connection.StartAsync();

            connection.On<string, string>("Send", (data1, data2) =>
            {
                Console.WriteLine($"{"User_"}{data1}{": "} {data2}");
            });

            string user = Guid.NewGuid().ToString();
            string value = Console.ReadLine();
            while (value != string.Empty)
            {
                connection.InvokeAsync("Send", user, value);
                value = Console.ReadLine();
            }
        }
    }
}