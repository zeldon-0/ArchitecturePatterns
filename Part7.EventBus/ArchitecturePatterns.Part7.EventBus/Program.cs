using ArchitecturePatterns.Part7.EventBus;

var eventBus = new EventBus();
var subscriber1 = new Subscriber("Subscriber1");
var subscriber2 = new Subscriber("Subscriber2");

eventBus.Subscribe<EventA>(subscriber1.HandleEvent);
eventBus.Subscribe<EventB>(subscriber2.HandleEvent);

eventBus.Publish(new EventA { Name = "Event1"});
eventBus.Publish(new EventB { Name = "Event2" });