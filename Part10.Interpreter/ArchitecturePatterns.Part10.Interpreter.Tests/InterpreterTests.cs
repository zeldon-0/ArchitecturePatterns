namespace ArchitecturePatterns.Part10.Interpreter.Tests;

public class InterpreterTests
{
    [Test]
    public void Interpret_AdditionExpression_ReturnsCorrectResult()
    {
        // Arrange
        var expression = new Addition(new Number(5), new Number(3));
        var expected = 8;

        // Act
        var result = expression.Interpret();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Interpret_SubtractionExpression_ReturnsCorrectResult()
    {
        // Arrange
        var expression = new Subtraction(new Number(10), new Number(3));
        var expected = 7;

        // Act
        var result = expression.Interpret();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Interpret_ComplexExpression_ReturnsCorrectResult()
    {
        // Arrange
        var expression = new Subtraction(
            new Addition(new Number(10), new Number(5)),
            new Number(3)
        );
        var expected = 12;

        // Act
        var result = expression.Interpret();

        // Assert
        Assert.AreEqual(expected, result);
    }
}