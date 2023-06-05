using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part6.PeerToPeer;

public class Peer
{
    private string name;
    private List<Peer> peers;

    public Peer(string name)
    {
        this.name = name;
        peers = new List<Peer>();
    }

    public void ConnectToPeer(Peer peer)
    {
        peers.Add(peer);
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{name} sent message: {message}");
        BroadcastMessage(message);
    }

    private void BroadcastMessage(string message)
    {
        foreach (Peer peer in peers)
        {
            peer.ReceiveMessage(message);
        }
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{name} received message: {message}");
    }
}

