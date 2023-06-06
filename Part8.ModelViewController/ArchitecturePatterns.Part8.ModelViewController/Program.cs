using ArchitecturePatterns.Part8.ModelViewController;

var model = new CalculatorModel();
var view = new CalculatorView();
var controller = new CalculatorController(model, view);

controller.Calculate(1, 10, "*");
