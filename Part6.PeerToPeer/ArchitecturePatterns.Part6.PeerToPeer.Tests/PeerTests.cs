using FluentAssertions;

namespace ArchitecturePatterns.Part6.PeerToPeer.Tests;

public class PeerTests
{
    [Test]
    public void SendMessage_DeliversMessageToPeers()
    {
        // Arrange
        var peer1 = new Peer("Peer1");
        var peer2 = new Peer("Peer2");
        var peer3 = new Peer("Peer3");

        // Act
        peer1.ConnectToPeer(peer2);
        peer1.ConnectToPeer(peer3);
        peer1.SendMessage("Hello, World!");

        // Assert
        peer1.ReceivedMessages.Should().BeEmpty();
        peer2.ReceivedMessages.Should().BeEquivalentTo(new List<string> { "Hello, World!" });
        peer3.ReceivedMessages.Should().BeEquivalentTo(new List<string> { "Hello, World!" });
    }
}
