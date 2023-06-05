using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part4.PipeFilter;
public class Pipeline
{
    private List<Filter> filters;

    public Pipeline()
    {
        filters = new List<Filter>();
    }

    public void AddFilter(Filter filter)
    {
        filters.Add(filter);
    }

    public Data Process(Data input)
    {
        var output = input;
        foreach (var filter in filters)
        {
            output = filter.Process(output);
        }
        return output;
    }
}
