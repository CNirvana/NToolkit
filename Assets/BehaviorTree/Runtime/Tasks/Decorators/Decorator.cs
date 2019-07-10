using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    public abstract class Decorator : Task
    {
        [Output(connectionType = ConnectionType.Override)]
        public Task child;

        public override object GetValue(NodePort port)
        {
            return null;
        }

        [ContextMenu("Execute child action")]
        public void ExecuteChildAction()
        {
            if(this.child != null)
            {
                var action = this.child as Action;
                if(action != null)
                {
                    action.Tick(0);
                }
            }
        }
    }
}