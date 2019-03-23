using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Nirvana.Attributes
{
    [CustomPropertyDrawer(typeof(SceneNameAttribute))]
    public class SceneNameAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "This attribute only support \"String\" type!", MessageType.Error);
            }
            else
            {
                var value = property.stringValue;
                var sceneNames = AttributeUtility.GetSceneNames();
                int selectedIndex = sceneNames.FindIndex(sceneName => sceneName == value);
                if (selectedIndex == -1)
                {
                    selectedIndex = 0;
                }

                selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, sceneNames.ToArray());
                if (selectedIndex == 0)
                {
                    property.stringValue = string.Empty;
                }
                else
                {
                    property.stringValue = sceneNames[selectedIndex];
                }
            }
        }
    }
}