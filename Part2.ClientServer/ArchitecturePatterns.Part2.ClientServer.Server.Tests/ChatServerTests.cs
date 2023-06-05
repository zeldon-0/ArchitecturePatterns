using System.Net.Sockets;
using System.Text;

namespace ArchitecturePatterns.Part2.ClientServer.Server.Tests;

public class ChatServerTests
{
    private const int TestPort = 8889;
    private ChatServer server;
    private TcpClient client1;
    private TcpClient client2;

    [SetUp]
    public void Setup()
    {
        server = new ChatServer();
        Thread serverThread = new Thread(server.Start);
        serverThread.Start();
    }

    [TearDown]
    public void TearDown()
    {
        server.RemoveClient(server.Clients[0]);
        server.RemoveClient(server.Clients[0]);
        server.Stop();
    }

    [Test]
    public void BroadcastMessage_SendsMessageToAllClientsExceptSender()
    {
        client1 = new TcpClient();
        client1.Connect("localhost", TestPort);
        StreamReader reader1 = new StreamReader(client1.GetStream(), Encoding.ASCII);
        StreamWriter writer1 = new StreamWriter(client1.GetStream(), Encoding.ASCII);
        writer1.AutoFlush = true;

        client2 = new TcpClient();
        client2.Connect("localhost", TestPort);
        StreamReader reader2 = new StreamReader(client2.GetStream(), Encoding.ASCII);
        StreamWriter writer2 = new StreamWriter(client2.GetStream(), Encoding.ASCII);
        writer2.AutoFlush = true;

        writer1.WriteLine("Client 1 message");
        string message1 = reader1.ReadLine();
        string message2 = reader2.ReadLine();

        Assert.AreEqual("Client 1 message", message2);
        Assert.IsNull(message1);

        reader1.Close();
        writer1.Close();
        client1.Close();

        reader2.Close();
        writer2.Close();
        client2.Close();
    }
}