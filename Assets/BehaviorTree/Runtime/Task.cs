using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    public abstract class Task : Node
    {
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Strict)]
        public Task parent;

        public virtual TaskStatue Tick(float deltaTime) { return TaskStatue.Success; }

        [ContextMenu("Print Name")]
        public void PrintName()
        {
            Debug.Log(this.name);
        }
    }
}