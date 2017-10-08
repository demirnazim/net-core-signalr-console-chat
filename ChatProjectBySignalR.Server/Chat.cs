using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatProjectBySignalR
{
    public class Chat : Hub
    {
        public Task Send(string Message1, string Message2)
        {
            return Clients.All.InvokeAsync("Send", Message1, Message2);
        }
    }
}