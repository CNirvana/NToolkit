using XNode;
using XNodeEditor;
using UnityEditorInternal;

namespace Nirvana.BT
{
    [CustomNodeEditor(typeof(Branch))]
    public class BranchEditor : TaskEditor
    {
        public override void OnBodyGUI()
        {
            this.DrawParentPort();
            this.ProcessParentPort();

            NodeEditorGUILayout.DynamicPortList("children", typeof(Task), this.serializedObject, NodePort.IO.Output, Node.ConnectionType.Override, Node.TypeConstraint.Strict, OnCreateReorderableList);

            var branch = this.target as Branch;
            int index = 0;
            foreach (var nodePort in this.target.DynamicOutputs)
            {
                if(nodePort.Connection == null)
                {
                    branch.children[index] = null;
                }
                else
                {
                    branch.children[index] = nodePort.Connection.node as Task;
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