using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    public abstract class Task : Node
    {
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Strict)]
        public Task parent;

        public virtual void Reset() { }
        public virtual TaskStatus Tick(float deltaTime) { return TaskStatus.Success; }

        [ContextMenu("Print Name")]
        public void PrintName()
        {
            Debug.Log(this.name);
        }
    }
}