using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part3.MasterSlave;

public class MasterNode
{
    private List<SlaveNode> slaveNodes;

    public MasterNode()
    {
        slaveNodes = new List<SlaveNode>();
    }

    public void RegisterSlave(SlaveNode slave)
    {
        slaveNodes.Add(slave);
    }

    public void DistributeTasks(List<string> tasks)
    {
        int slaveIndex = 0;
        var tasksList = new List<Task>();
        foreach (string task in tasks)
        {
            var currentSlave = slaveNodes[slaveIndex];
            tasksList.Add(currentSlave.ExecuteTask(task));

            slaveIndex = (slaveIndex + 1) % slaveNodes.Count;
        }

        Task.WhenAll(tasksList).Wait();
    }
}
