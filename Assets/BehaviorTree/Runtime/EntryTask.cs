using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    public class EntryTask : Task
    {
        [Output(connectionType = ConnectionType.Override)]
        [SerializeField]
        public Task child;

        public override object GetValue(NodePort port)
        {
            return null;
        }

        [ContextMenu("Print Child")]
        public void PrintChild()
        {
        }
    }
}