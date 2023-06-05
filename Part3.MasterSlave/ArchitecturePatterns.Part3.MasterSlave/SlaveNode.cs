using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part3.MasterSlave;

public class SlaveNode
{
    public List<string> CompletedTasks = new ();

    public async Task ExecuteTask(string task)
    {
        Console.WriteLine("Task execution started: " + task);
        Console.WriteLine("Task execution completed: " + task);
        CompletedTasks.Add(task);
    }
}