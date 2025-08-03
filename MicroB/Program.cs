// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;

const string username = "Reem";
Console.WriteLine("send a message to A");


await using var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5219/chatHub")
    .Build();

await connection.StartAsync();
connection.On<string,string>("ReceiveMessage", (user, message) =>
{
    Console.WriteLine($"{user}:{message}");
});
while (true)
{
   // Console.Write(username+": ");
    var mess =Console.ReadLine();
    await connection.InvokeAsync("SendMessage", username,mess);
    
}

