using XNode;
using XNodeEditor;
using UnityEngine;
using UnityEditor;

namespace Nirvana.BT
{
    [CustomNodeEditor(typeof(Composite))]
    public class CompositeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
        }
    }
}