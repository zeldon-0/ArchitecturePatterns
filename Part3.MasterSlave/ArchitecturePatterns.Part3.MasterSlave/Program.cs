using ArchitecturePatterns.Part3.MasterSlave;

var slave1 = new SlaveNode();
var slave2 = new SlaveNode();

var master = new MasterNode();
master.RegisterSlave(slave1);
master.RegisterSlave(slave2);

master.DistributeTasks(new List<string> { "SomeTask1", "SomeTask2" });