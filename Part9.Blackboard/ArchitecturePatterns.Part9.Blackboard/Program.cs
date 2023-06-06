using ArchitecturePatterns.Part9.Blackboard;

var blackboard = new Blackboard();
var knowledgeSource = new KnowledgeSource(blackboard);
var solver = new Solver(blackboard);

knowledgeSource.ProvideKnowledge();
solver.SolveProblem();

Console.WriteLine($"Got the following knowledge from solving a problem: {blackboard.GetKnowledge<string>("Solution")}");