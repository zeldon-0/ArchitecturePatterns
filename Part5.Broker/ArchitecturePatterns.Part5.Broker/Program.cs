using ArchitecturePatterns.Part5.Broker;

var broker = new Broker();

var firstPublisher = new Publisher(broker);
var secondPublisher = new Publisher(broker);

var firstSubscriber = new Subscriber("Subscriber1");
var secondSubscriber = new Subscriber("Subscriber2");

broker.Subscribe("topic1", firstSubscriber);
broker.Subscribe("topic1", secondSubscriber);
broker.Subscribe("topic2", secondSubscriber);

firstPublisher.Publish(new Message { Content = "Message1", Topic = "topic1"});
broker.Unsubscribe("topic1", secondSubscriber);
firstPublisher.Publish(new Message { Content = "Message2", Topic = "topic1" });
secondPublisher.Publish(new Message { Content = "Message3", Topic = "topic2" });