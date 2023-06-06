using ArchitecturePatterns.Part10.Interpreter;

var leftOperand = new Number(1);
var rightOperand = new Number(5);
var addition = new Addition(leftOperand, rightOperand);

var outerLeftOperand = new Number(24);
var subtraction = new Subtraction(outerLeftOperand, addition);

Console.WriteLine($"The expression execution result is: {subtraction.Interpret()}");