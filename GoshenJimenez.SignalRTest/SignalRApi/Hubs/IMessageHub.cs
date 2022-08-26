using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRApi.Hubs
{    
    public interface IMessageHub
    {
        Task SendMessage(string user, string message);
    }


    public class MessageHub : Hub<IMessageHub>
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendMessage(user, message);
        }
    }
}
