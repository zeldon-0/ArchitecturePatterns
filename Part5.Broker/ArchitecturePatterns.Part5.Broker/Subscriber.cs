using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part5.Broker;
public class Subscriber
{
    private string name;

    public Subscriber(string name)
    {
        this.name = name;
    }

    public void ReceiveMessage(Message message)
    {
        // Process the received message
        Console.WriteLine($"Subscriber {name} received message: {message.Content}");
    }
}
