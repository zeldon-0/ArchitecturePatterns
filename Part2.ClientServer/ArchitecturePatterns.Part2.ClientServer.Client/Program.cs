using System.Net.Sockets;
using System.Text;

TcpClient client = new TcpClient();
Console.WriteLine("Connecting to server...");
client.Connect("localhost", 8888);
Console.WriteLine("Connected to server...");

StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);
StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.ASCII);
writer.AutoFlush = true;

Console.WriteLine("Enter your name:");
string name = Console.ReadLine();
writer.WriteLine(name);

string serverMessage;
try
{
    while (true)
    {
        serverMessage = reader.ReadLine();
        Console.WriteLine("Received message: " + serverMessage);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
finally
{
    reader.Close();
    writer.Close();
    client.Close();
}