using UnityEditor;
using UnityEngine;

namespace Nirvana.Attributes
{
    [CustomPropertyDrawer(typeof(FolderPathAttribute))]
    public class FolderPathAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if(property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "This attribute only support \"String\" type!", MessageType.Error);
            }
            else
            {
                var textRect = new Rect(position.x, position.y, position.width - 32.0f, position.height);
                property.stringValue = EditorGUI.TextField(textRect, label, property.stringValue);

                var buttonRect = new Rect(position.x + textRect.width + 2.0f, position.y, 30.0f, position.height);
                if(GUI.Button(buttonRect, EditorGUIUtility.IconContent("Folder Icon")))
                {
                    var newPath = EditorUtility.OpenFolderPanel("Select Folder", property.stringValue, "");
                    if(newPath != property.stringValue)
                    {
                        property.stringValue = newPath;
                    }
                }
            }
        }
    }
}