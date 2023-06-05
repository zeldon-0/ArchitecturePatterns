using System.Net.Sockets;
using System.Text;
using ArchitecturePatterns.Part2.ClientServer.Server;

namespace ArchitecturePatterns.Part2.ClientServer.Client.Tests
{
    public class ClientProgramTests
    {
        private const int TestPort = 8889;
        private ChatServer server;
        private TcpClient client;

        [SetUp]
        public void Setup()
        {
            server = new ChatServer();
            server.Start();
        }

        [TearDown]
        public void TearDown()
        {
            server.Stop();
        }

        [Test]
        public void ClientProgram_ReceivesMessagesFromServer()
        {
            client = new TcpClient();
            client.Connect("localhost", TestPort);
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);
            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.ASCII);
            writer.AutoFlush = true;

            string name = "TestClient";
            writer.WriteLine(name);

            writer.WriteLine("Server message");
            string message = reader.ReadLine();

            Assert.AreEqual("Server message", message);

            reader.Close();
            writer.Close();
            client.Close();
        }
    }
}