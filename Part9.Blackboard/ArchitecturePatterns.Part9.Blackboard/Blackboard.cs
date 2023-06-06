using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part9.Blackboard;

public class Blackboard
{
    private Dictionary<string, object> knowledge;

    public Blackboard()
    {
        knowledge = new Dictionary<string, object>();
    }

    public void AddKnowledge(string key, object value)
    {
        knowledge[key] = value;
    }

    public T GetKnowledge<T>(string key)
    {
        if (knowledge.ContainsKey(key))
        {
            return (T)knowledge[key];
        }
        return default(T);
    }

    public void RemoveKnowledge(string key)
    {
        knowledge.Remove(key);
    }
}