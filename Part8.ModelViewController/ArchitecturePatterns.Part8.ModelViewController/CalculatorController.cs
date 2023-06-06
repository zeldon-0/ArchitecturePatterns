using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part8.ModelViewController;
public class CalculatorController
{
    private CalculatorModel model;
    private CalculatorView view;

    public CalculatorController(CalculatorModel model, CalculatorView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Calculate(int a, int b, string operation)
    {
        int result;

        switch (operation)
        {
            case "+":
                result = model.Add(a, b);
                break;
            case "-":
                result = model.Subtract(a, b);
                break;
            case "*":
                result = model.Multiply(a, b);
                break;
            case "/":
                result = model.Divide(a, b);
                break;
            default:
                throw new ArgumentException("Invalid operation.");
        }

        view.DisplayResult(result);
    }
}
