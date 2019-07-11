using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    public class EntryTask : Task
    {
        [Output(connectionType = ConnectionType.Override)]
        [SerializeField]
        public Task child;

        public override TaskStatus Tick(float deltaTime)
        {
            return this.child.Tick(deltaTime);
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}