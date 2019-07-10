using XNodeEditor;

namespace Nirvana.BT
{
    [CustomNodeEditor(typeof(EntryTask))]
    public class EntryTaskEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            var entryTask = this.target as EntryTask;

            var childPort = this.target.GetOutputPort("child");
            NodeEditorGUILayout.PortField(childPort);

            if(childPort.Connection == null)
            {
                entryTask.child = null;
            }
            else
            {
                var child = childPort.Connection.node;
                if(entryTask.child == null || entryTask.child != child)
                {
                    entryTask.child = child as Task;
                }
            }
        }
    }
}