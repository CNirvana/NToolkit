using UnityEngine;
using UnityEditor;

namespace Nirvana.Attributes
{
    [CustomPropertyDrawer(typeof(InfoBoxAttribute))]
    public class InfoBoxAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 2 * base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var infoBoxAttribute = this.attribute as InfoBoxAttribute;
            var pos = new Rect(position.x, position.y, position.width, position.height * 0.5f);
            EditorGUI.HelpBox(pos, infoBoxAttribute.Message, AttributeUtility.ConvertToUnityMsgType(infoBoxAttribute.Type));
            pos.y += pos.height;
            EditorGUI.PropertyField(pos, property, label, true );
        }
    }
}