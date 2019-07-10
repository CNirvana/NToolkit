using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;

namespace Nirvana.BT
{
    [CustomNodeGraphEditor(typeof(BehaviorGraph), "BehaviorGraph.settings")]
    public class BehaviorGraphEditor : NodeGraphEditor
    {
        public override void OnGUI()
        {
            NodeEditorWindow.current.Repaint();
        }

        // public override string GetNodeMenuName(System.Type type)
        // {
        // }

        public override NodeEditorPreferences.Settings GetDefaultPreferences()
        {
            return new NodeEditorPreferences.Settings() {
                gridBgColor = Color.gray,
                gridLineColor = Color.white,
                typeColors = new Dictionary<string, Color>() {
                    { typeof(string).PrettyName(), Color.yellow },
                    { typeof(Task).PrettyName(), new Color(1,0.5f,0.6f) }
                }
            };
        }
    }
}