using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace ArchitecturePatterns.Part3.MasterSlave.Tests;

public class SlaveNodeTests
{
    private SlaveNode slaveNode;

    [SetUp]
    public void Setup()
    {
        slaveNode = new SlaveNode();
    }

    [Test]
    public void ExecuteTask_PerformsTaskExecution()
    {
        string task = "Task 1";

        slaveNode.ExecuteTask(task).Wait();
        slaveNode.CompletedTasks.Single().Should().Be(task);
    }
}
