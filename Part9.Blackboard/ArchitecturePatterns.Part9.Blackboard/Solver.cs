using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part9.Blackboard;
public class Solver
{
    private Blackboard blackboard;

    public Solver(Blackboard blackboard)
    {
        this.blackboard = blackboard;
    }

    public void SolveProblem()
    {
        var knowledge = blackboard.GetKnowledge<string>("Key");
        var derivedKnowledge = $"{knowledge} after some transformation";

        blackboard.AddKnowledge("Solution", derivedKnowledge);
    }
}