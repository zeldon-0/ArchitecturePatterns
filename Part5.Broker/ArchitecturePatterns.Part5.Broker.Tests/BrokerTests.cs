using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ArchitecturePatterns.Part5.Broker.Tests;

public class BrokerTests
{
    private Broker broker;

    [SetUp]
    public void Setup()
    {
        broker = new Broker();
    }

    [Test]
    public void Publish_DeliversMessageToSubscribers()
    {
        // Arrange
        var subscriber1 = new Subscriber("Subscriber1");
        var subscriber2 = new Subscriber("Subscriber2");
        var message1 = new Message { Content = "Message1", Topic = "Topic1" };
        var message2 = new Message { Content = "Message2", Topic = "Topic2" };

        // Act
        broker.Subscribe("Topic1", subscriber1);
        broker.Subscribe("Topic2", subscriber2);
        broker.Publish(message1);
        broker.Publish(message2);
        
        // Assert
        subscriber1.ReceivedMessages.Should().BeEquivalentTo(new List<string> { "Message1" });
        subscriber2.ReceivedMessages.Should().BeEquivalentTo(new List<string> { "Message2" });
    }

    [Test]
    public void Unsubscribe_RemovesSubscriberFromTopic()
    {
        // Arrange
        var subscriber = new Subscriber("Subscriber");
        var message = new Message { Content = "Message1",Topic = "Topic" };

        // Act
        broker.Subscribe("Topic", subscriber);
        broker.Unsubscribe("Topic", subscriber);
        broker.Publish(message);

        // Assert
        subscriber.ReceivedMessages.Should().BeEmpty();
    }
}