using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part5.Broker;
public class Subscriber
{
    public List<string> ReceivedMessages { get; set; }
    private string name;

    public Subscriber(string name)
    {
        this.name = name;
    }

    public void ReceiveMessage(Message message)
    {
        Console.WriteLine($"Subscriber {name} received message: {message.Content}");
        ReceivedMessages.Add(message.Content);
    }
}
