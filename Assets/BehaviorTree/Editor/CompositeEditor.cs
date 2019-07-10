using XNode;
using XNodeEditor;
using UnityEditorInternal;

namespace Nirvana.BT
{
    [CustomNodeEditor(typeof(Composite))]
    public class CompositeEditor : TaskEditor
    {
        public override void OnBodyGUI()
        {
            this.DrawParentPort();
            this.ProcessParentPort();

            NodeEditorGUILayout.DynamicPortList("children", typeof(Task), this.serializedObject, NodePort.IO.Output, Node.ConnectionType.Override, Node.TypeConstraint.Strict, OnCreateReorderableList);

            var composite = this.target as Composite;
            int index = 0;
            foreach (var nodePort in this.target.DynamicOutputs)
            {
                if(nodePort.Connection == null)
                {
                    composite.children[index] = null;
                }
                else
                {
                    composite.children[index] = nodePort.Connection.node as Task;
                }

                index++;
            }
        }

        private void OnCreateReorderableList(ReorderableList list)
        {
            // list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {

            };
        }
    }
}