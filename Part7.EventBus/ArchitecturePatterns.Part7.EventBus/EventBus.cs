using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part7.EventBus;
public class EventBus
{
    private Dictionary<Type, List<Action<object>>> eventHandlers;

    public EventBus()
    {
        eventHandlers = new Dictionary<Type, List<Action<object>>>();
    }

    public void Publish<TEvent>(TEvent e) where TEvent : Event
    {
        Type eventType = typeof(TEvent);
        if (eventHandlers.ContainsKey(eventType))
        {
            foreach (Action<object> handler in eventHandlers[eventType])
            {
                handler(e);
            }
        }
    }

    public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : Event
    {
        Type eventType = typeof(TEvent);
        if (!eventHandlers.ContainsKey(eventType))
        {
            eventHandlers[eventType] = new List<Action<object>>();
        }
        eventHandlers[eventType].Add(obj => handler((TEvent)obj));
    }

    public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : Event
    {
        Type eventType = typeof(TEvent);
        if (eventHandlers.ContainsKey(eventType))
        {
            eventHandlers[eventType].Remove(obj => handler((TEvent)obj));
        }
    }
}