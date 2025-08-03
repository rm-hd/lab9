using Microsoft.AspNetCore.SignalR;

namespace ChatSever.Hubs;

public class ChatHub:Hub
{

    public async Task SendMessage(string username,string message)
    {
        await Clients.Others.SendAsync("ReceiveMessage",username, message);
        
    }

    
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveMessage", "System", "A user left the chat");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.SendAsync("ReceiveMessage", "System", "A user left the chat");
        await base.OnDisconnectedAsync(exception);
    }
    
    
    
}