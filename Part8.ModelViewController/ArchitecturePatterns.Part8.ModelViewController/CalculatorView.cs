using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part8.ModelViewController;
public class CalculatorView
{
    public string LatestEvent;
    public void DisplayResult(int result)
    {
        var output = $"Result: {result}";
        Console.WriteLine(output);
        LatestEvent = output;
    }
}