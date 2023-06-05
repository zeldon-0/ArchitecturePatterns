using FluentAssertions;

namespace ArchitecturePatterns.Part3.MasterSlave.Tests;
public class MasterNodeTests
{
    private MasterNode masterNode;
    private List<SlaveNode> slaveNodes;

    [SetUp]
    public void Setup()
    {
        masterNode = new MasterNode();
        slaveNodes = new List<SlaveNode>();
        for (int i = 0; i < 3; i++)
        {
            slaveNodes.Add(new SlaveNode());
            masterNode.RegisterSlave(slaveNodes[i]);
        }
    }

    [Test]
    public void DistributeTasks_CallsExecuteTaskOnSlaves()
    {
        var tasks = new List<string> { "Task 1", "Task 2", "Task 3", "Task 4", "Task 5" };

        masterNode.DistributeTasks(tasks);

        foreach (var slave in slaveNodes)
        {
            slave.CompletedTasks.Should().BeEquivalentTo(tasks);
        }
    }
}
