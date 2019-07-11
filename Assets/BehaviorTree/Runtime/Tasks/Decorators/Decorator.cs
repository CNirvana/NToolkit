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
    }
}