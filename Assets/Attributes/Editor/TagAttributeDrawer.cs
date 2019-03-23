using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Nirvana.Attributes
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                return 2 * base.GetPropertyHeight(property, label);
            }
            else
            {
                return base.GetPropertyHeight(property, label);
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                var pos = new Rect(position.x, position.y, position.width, position.height * 0.5f);
                EditorGUI.HelpBox(pos, "This attribute only support \"String\" type!", MessageType.Error);
                pos.y += pos.height;
                EditorGUI.PropertyField(pos, property, label, true);
            }
            else
            {
                var tags = AttributeUtility.GetTags();

                var value = property.stringValue;
                int selectedIndex = tags.FindIndex(tag => tag == value);
                if (selectedIndex == -1)
                {
                    selectedIndex = 0;
                }

                selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, tags.ToArray());

                if (selectedIndex == 0)
                {
                    property.stringValue = string.Empty;
                }
                else
                {
                    property.stringValue = tags[selectedIndex];
                }
            }
        }
    }
}