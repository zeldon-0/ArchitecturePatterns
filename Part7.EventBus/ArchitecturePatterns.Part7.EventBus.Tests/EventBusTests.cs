using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace ArchitecturePatterns.Part7.EventBus.Tests;
public class EventBusTests
{
    [Test]
    public void Publish_DeliversEventToSubscribers()
    {
        // Arrange
        var eventBus = new EventBus();
        var subscriber1 = new Subscriber("Subscriber1");
        var subscriber2 = new Subscriber("Subscriber2");

        // Act
        eventBus.Subscribe<EventA>(subscriber1.HandleEvent);
        eventBus.Subscribe<EventB>(subscriber2.HandleEvent);
        eventBus.Publish(new EventA { Name = "Event1" });
        eventBus.Publish(new EventB { Name = "Event2" });

        // Assert
        subscriber1.HandledEvents.Single().Should().Be("Event1");
        subscriber2.HandledEvents.Single().Should().Be("Event2");
    }

    [Test]
    public void Unsubscribe_RemovesSubscriberFromEvent()
    {
        // Arrange
        var eventBus = new EventBus();
        var subscriber = new Subscriber("Subscriber1");
        
        // Act
        eventBus.Subscribe<EventA>(subscriber.HandleEvent);
        eventBus.Publish(new EventA { Name = "Event1" });
        eventBus.Unsubscribe<EventA>(subscriber.HandleEvent);
        eventBus.Publish(new EventA { Name = "Event2" });

        // Assert
        subscriber.HandledEvents.Single().Should().Be("Event1");
    }
}
