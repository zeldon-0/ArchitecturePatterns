using System.Net.Sockets;
using System.Text;

namespace ArchitecturePatterns.Part2.ClientServer.Server;
public class ClientHandler
{
    private TcpClient client;
    private ChatServer server;
    private StreamReader reader;
    private StreamWriter writer;

    public ClientHandler(TcpClient client, ChatServer server)
    {
        this.client = client;
        this.server = server;
    }

    public void HandleClient()
    {
        reader = new StreamReader(client.GetStream(), Encoding.ASCII);
        writer = new StreamWriter(client.GetStream(), Encoding.ASCII);
        writer.AutoFlush = true;

        string clientMessage;
        try
        {
            while ((clientMessage = reader.ReadLine()) != null)
            {
                Console.WriteLine("Received message: " + clientMessage);
                server.BroadcastMessage(clientMessage, this);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            server.RemoveClient(this);
            reader.Close();
            writer.Close();
            client.Close();
        }
    }

    public void SendMessage(string message)
    {
        writer.WriteLine(message);
    }
}
