using ArchitecturePatterns.Part6.PeerToPeer;

var peer1 = new Peer("Peer1");
var peer2 = new Peer("Peer2");
var peer3 = new Peer("Peer3");
var allPeers = new List<Peer> { peer1, peer2, peer3 };

foreach (var peer in allPeers)
{
    foreach (var remainingPeer in allPeers.Where(p => !p.Equals(peer)))
    {
        peer.ConnectToPeer(remainingPeer);
    }
}

peer1.SendMessage("Henlo");

peer2.SendMessage("Haiiiii");

peer3.SendMessage("Hiiiiiii");
