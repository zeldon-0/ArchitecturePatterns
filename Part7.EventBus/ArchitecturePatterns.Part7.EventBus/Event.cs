using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part7.EventBus;
public class Event
{
    public string Name { get; set; }
}

public class EventA : Event {}

public class EventB : Event { }