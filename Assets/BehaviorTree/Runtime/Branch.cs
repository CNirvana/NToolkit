using System.Collections.Generic;
using XNode;

namespace Nirvana.BT
{
    public class Branch : Task
    {
        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override, dynamicPortList = true)]
        public List<Task> children = new List<Task>();

        public int ActiveChild { get; protected set; }
        public int ChildCount { get { return this.children.Count; } }

        public override void Reset()
        {
            this.ActiveChild = 0;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}