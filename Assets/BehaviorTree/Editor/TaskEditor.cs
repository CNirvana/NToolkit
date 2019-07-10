using XNodeEditor;

namespace Nirvana.BT
{
    [CustomNodeEditor(typeof(Task))]
    public class TaskEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            this.ProcessParentPort();
        }

        public void DrawParentPort()
        {
            var parentPort = this.target.GetInputPort("parent");
            NodeEditorGUILayout.PortField(parentPort);
        }

        public void ProcessParentPort()
        {
            var task = this.target as Task;

            var parentPort = this.target.GetInputPort("parent");
            if(parentPort.Connection == null)
            {
                task.parent = null;
            }
            else
            {
                var parent = parentPort.Connection.node;
                if(task.parent == null || task.parent != parent)
                {
                    task.parent = parent as Task;
                }
            }
        }
    }
}