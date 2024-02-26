using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomGroupProcessor(typeof(GroupAttribute))]
    public class GroupAttributeProcessor : PropertyGroupProcessor
    {
        public override void BeginPropertyGroup()
        {
            LucidEditorGUILayout.BeginLayoutIndent(EditorGUI.indentLevel);
            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.MinWidth(0));
        }

        public override void EndPropertyGroup()
        {
            EditorGUILayout.EndVertical();
            LucidEditorGUILayout.EndLayoutIndent();
            
            EditorGUILayout.Space(2);
        }
    }
}