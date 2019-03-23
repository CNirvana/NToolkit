using System;
using UnityEngine;

namespace Nirvana.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class InfoBoxAttribute : PropertyAttribute
    {
        public enum MessageType { None, Info, Warning, Error }

        public MessageType Type { get; private set; }
        public string Message { get; private set; }

        public InfoBoxAttribute(string message, MessageType type = MessageType.None)
        {
            this.Message = message;
            this.Type = type;
        }
    }
}