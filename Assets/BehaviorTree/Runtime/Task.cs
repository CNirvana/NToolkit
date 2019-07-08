using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    public abstract class Task : Node
    {
        [Input]
        public TaskConnection parent;

        public virtual TaskStatue Tick(float deltaTime) { return TaskStatue.Success; }

        [ContextMenu("Print Name")]
        public void PrintName()
        {
            Debug.Log(this.name);
        }
    }
}