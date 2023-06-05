using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part5.Broker;
public class Broker
{
    private Dictionary<string, List<Subscriber>> topicSubscribers;

    public Broker()
    {
        topicSubscribers = new Dictionary<string, List<Subscriber>>();
    }

    public void Subscribe(string topic, Subscriber subscriber)
    {
        if (!topicSubscribers.ContainsKey(topic))
        {
            topicSubscribers[topic] = new List<Subscriber>();
        }
        topicSubscribers[topic].Add(subscriber);
    }

    public void Unsubscribe(string topic, Subscriber subscriber)
    {
        if (topicSubscribers.ContainsKey(topic))
        {
            topicSubscribers[topic].Remove(subscriber);
        }
    }

    public void Publish(Message message)
    {
        if (topicSubscribers.ContainsKey(message.Topic))
        {
            foreach (var subscriber in topicSubscribers[message.Topic])
            {
                subscriber.ReceiveMessage(message);
            }
        }
    }
}