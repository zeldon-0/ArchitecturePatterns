using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part4.PipeFilter;

public abstract class Filter
{
    public abstract Data Process(Data input);
}


public class UppercaseFilter : Filter
{
    public override Data Process(Data input)
    {
        string processedValue = input.Value.ToUpper();
        return new Data { Value = processedValue };
    }
}

public class ReverseFilter : Filter
{
    public override Data Process(Data input)
    {
        char[] charArray = input.Value.ToCharArray();
        Array.Reverse(charArray);
        string processedValue = new string(charArray);
        return new Data { Value = processedValue };
    }
}