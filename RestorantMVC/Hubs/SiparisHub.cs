using Microsoft.AspNetCore.SignalR;

namespace RestorantMVC.Hubs
{
    public sealed class SiparisHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            this.Clients.All.SendAsync("ReceiveMessage",$"{Context.ConnectionId} has joined");
        }
        public async Task YeniSiparisGeldi(int id)
        {
            await Clients.All.SendAsync("YeniSiparis" , id);
        }
    }
}
