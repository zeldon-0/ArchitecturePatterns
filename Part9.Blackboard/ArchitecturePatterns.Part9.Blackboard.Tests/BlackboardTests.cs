namespace ArchitecturePatterns.Part9.Blackboard.Tests;
public class BlackboardTests
{
    [Test]
    public void AddKnowledge_AddsKnowledgeToBlackboard()
    {
        // Arrange
        var blackboard = new Blackboard();
        var key = "Key";
        var value = "Value";

        // Act
        blackboard.AddKnowledge(key, value);
        var retrievedValue = blackboard.GetKnowledge<string>(key);

        // Assert
        Assert.AreEqual(value, retrievedValue);
    }

    [Test]
    public void GetKnowledge_ReturnsDefaultValueForUnknownKey()
    {
        // Arrange
        var blackboard = new Blackboard();
        var key = "UnknownKey";

        // Act
        var retrievedValue = blackboard.GetKnowledge<string>(key);

        // Assert
        Assert.AreEqual(default(string), retrievedValue);
    }

    [Test]
    public void RemoveKnowledge_RemovesKnowledgeFromBlackboard()
    {
        // Arrange
        var blackboard = new Blackboard();
        var key = "Key";
        var value = "Value";

        // Act
        blackboard.AddKnowledge(key, value);
        blackboard.RemoveKnowledge(key);
        var retrievedValue = blackboard.GetKnowledge<string>(key);

        // Assert
        Assert.AreEqual(default(string), retrievedValue);
    }
}