using Microsoft.AspNetCore.SignalR;
using SignalRHub.WebAPI.Models;

namespace SignalRHub.WebAPI.Hubs
{
    public class SignalHub : Hub
    {
        public void BroadcastEmployee(Employee employee)
        {
            Clients.All.SendAsync("ReceiveEmployee", employee);
        }

        public void BroadcaseMessage(string message)
        {
            Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
