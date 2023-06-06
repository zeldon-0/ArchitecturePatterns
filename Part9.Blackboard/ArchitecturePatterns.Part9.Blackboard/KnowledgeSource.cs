using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part9.Blackboard;
public class KnowledgeSource
{
    private Blackboard blackboard;

    public KnowledgeSource(Blackboard blackboard)
    {
        this.blackboard = blackboard;
    }

    public void ProvideKnowledge()
    {
        blackboard.AddKnowledge("Key", "Value");
    }
}