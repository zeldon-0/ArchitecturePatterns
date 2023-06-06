namespace ArchitecturePatterns.Part8.ModelViewController.Tests;
using Moq;

public class CalculatorControllerTests
{
    [Test]
    public void Calculate_AddsTwoNumbers()
    {
        // Arrange
        var a = 5;
        var b = 3;
        var operation = "+";
        var expected = 8;

        var model = new CalculatorModel();
        var view = new CalculatorView();
        var controller = new CalculatorController(model, view);

        // Act
        controller.Calculate(a, b, operation);

        // Assert
        Mock.Get(view).Verify(v => v.DisplayResult(expected), Times.Once());
    }

    [Test]
    public void Calculate_DividesTwoNumbers()
    {
        // Arrange
        var a = 10;
        var b = 2;
        var operation = "/";
        var expected = 5;

        var model = new CalculatorModel();
        var view = new CalculatorView();
        var controller = new CalculatorController(model, view);

        // Act
        controller.Calculate(a, b, operation);

        // Assert
        Mock.Get(view).Verify(v => v.DisplayResult(expected), Times.Once());
    }
}
