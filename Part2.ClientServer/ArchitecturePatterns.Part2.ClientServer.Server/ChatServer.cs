using System.Net;
using System.Net.Sockets;

namespace ArchitecturePatterns.Part2.ClientServer.Server;
public class ChatServer
{
    public List<ClientHandler> Clients;

    private TcpListener server;
    
    public ChatServer()
    {
        Clients = new List<ClientHandler>();
    }

    public void Start()
    {
        server = new TcpListener(IPAddress.Any, 8888);
        server.Start();

        Console.WriteLine("Chat server started on port 8888...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("New client connected...");

            ClientHandler clientHandler = new ClientHandler(client, this);
            Clients.Add(clientHandler);
            Thread clientThread = new Thread(clientHandler.HandleClient);
            clientThread.Start();
        }
    }

    public void Stop()
    {
        server.Stop();
    }

    public void BroadcastMessage(string message, ClientHandler sender)
    {
        foreach (ClientHandler client in Clients)
        {
            if (client != sender)
            {
                client.SendMessage(message);
            }
        }
    }

    public void RemoveClient(ClientHandler client)
    {
        Clients.Remove(client);
    }
}
