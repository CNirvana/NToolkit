using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

namespace Nirvana.Attributes
{
    public static class AttributeUtility
    {
        public static List<string> GetTags()
        {
            var tags = new List<string>();
            tags.Add("[None]");
            tags.AddRange(UnityEditorInternal.InternalEditorUtility.tags);

            return tags;
        }

        public static List<string> GetSceneNames()
        {
            var sceneNames = new List<string>() { "[None]" };
            var scenes = EditorBuildSettings.scenes;
            foreach (var scene in scenes)
            {
                var path = scene.path;
                if (!string.IsNullOrEmpty(path))
                {
                    sceneNames.Add(System.IO.Path.GetFileNameWithoutExtension(path));
                }
            }

            return sceneNames;
        }

        public static T GetAttribute<T>(SerializedProperty serializedProperty) where T : Attribute
        {
            var target = serializedProperty.serializedObject.targetObject;
            var type = target.GetType();
            var field = type.GetField(serializedProperty.name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
            {
                return null;
            }

            var attribute = field.GetCustomAttribute<T>(true);
            return attribute;
        }

        public static MessageType ConvertToUnityMsgType(InfoBoxAttribute.MessageType messageType)
        {
            switch (messageType)
            {
                case InfoBoxAttribute.MessageType.None:
                    return MessageType.None;
                case InfoBoxAttribute.MessageType.Info:
                    return MessageType.Info;
                case InfoBoxAttribute.MessageType.Warning:
                    return MessageType.Warning;
                case InfoBoxAttribute.MessageType.Error:
                    return MessageType.Error;
                default:
                    return MessageType.None;
            }
        }
    }
}