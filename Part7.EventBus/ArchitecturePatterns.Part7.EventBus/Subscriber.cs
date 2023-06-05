using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part7.EventBus;

public class Subscriber
{
    private string name;

    public List<string> HandledEvents = new();

    public Subscriber(string name)
    {
        this.name = name;
    }

    public void HandleEvent(Event e)
    {
        Console.WriteLine($"Subscriber {name} received event: {e.Name}");
        HandledEvents.Add(e.Name);
    }
}