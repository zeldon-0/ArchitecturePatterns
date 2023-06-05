using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part5.Broker;
public class Publisher
{
    private Broker broker;

    public Publisher(Broker broker)
    {
        this.broker = broker;
    }

    public void Publish(Message message)
    {
        broker.Publish(message);
    }
}
