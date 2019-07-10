using System.Collections.Generic;
using XNode;

namespace Nirvana.BT
{
    public abstract class Composite : Task
    {
        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override, dynamicPortList = true)]
        public List<Task> children = new List<Task>();

        public int ChildCount { get { return this.children.Count; } }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}