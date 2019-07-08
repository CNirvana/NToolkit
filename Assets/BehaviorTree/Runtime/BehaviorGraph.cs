using UnityEngine;
using XNode;

namespace Nirvana.BT
{
    [CreateAssetMenu(fileName = "New Behavior Graph", menuName = "Nirvana/BT/Behavior Graph")]
    public class BehaviorGraph : NodeGraph
    {
        [ContextMenu("Debug Info")]
        public void DebugInfo()
        {
            Debug.Log("Graph");
        }
    }
}