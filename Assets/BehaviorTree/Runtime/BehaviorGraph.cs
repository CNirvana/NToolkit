using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    [CreateAssetMenu(fileName = "New Behavior Graph", menuName = "Nirvana/BT/Behavior Graph")]
    public class BehaviorGraph : NodeGraph
    {
        public void Initialize()
        {
            foreach(var node in this.nodes)
            {
                var task = node as Task;
                if(task != null)
                {
                    task.Reset();
                }
            }
        }

        public EntryTask GetEntryTask()
        {
            foreach(var node in this.nodes)
            {
                var entry = node as EntryTask;
                if(entry != null)
                {
                    return entry;
                }
            }

            return null;
        }
    }
}