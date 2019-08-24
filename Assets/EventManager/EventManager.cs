using System;
using System.Collections.Generic;

namespace Nirvana.Toolkit
{
    public static class EventManager
    {
        private static Dictionary<Type, List<IEventListener>> _eventMap = new Dictionary<Type, List<IEventListener>>();

        public static void AddListener<T>(IEventListener<T> listener) where T : struct, IEvent
        {
            var type = typeof(T);
            if(!_eventMap.TryGetValue(type, out var listeners))
            {
                listeners = new List<IEventListener>();
                _eventMap.Add(type, listeners);
            }

            listeners.Add(listener);
        }

        public static void RemoveListener<T>(IEventListener<T> listener) where T : struct, IEvent
        {
            var type = typeof(T);
            if(_eventMap.TryGetValue(type, out var listeners))
            {
                listeners.Remove(listener);
            }
        }

        public static void Raise<T>(T e) where T : struct, IEvent
        {
            if(_eventMap.TryGetValue(typeof(T), out var listeners))
            {
                foreach(var listener in listeners)
                {
                    (listener as IEventListener<T>).OnEvent(e);
                }
            }
        }
    }
}