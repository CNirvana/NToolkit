using XNode;

namespace Nirvana.BT
{
    public class EntryTask : Node
    {
        [Output]
        public TaskConnection child;

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}