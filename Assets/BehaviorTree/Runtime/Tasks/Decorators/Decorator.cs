using XNode;

namespace Nirvana.BT
{
    public abstract class Decorator : Task
    {
        [Output]
        public TaskConnection child;

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}