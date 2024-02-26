using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomGroupProcessor(typeof(BoxGroupAttribute))]
    public class BoxGroupAttributeProcessor : PropertyGroupProcessor
    {
        public override void BeginPropertyGroup()
        {
            LucidEditorGUILayout.BeginLayoutIndent(EditorGUI.indentLevel);
            LucidEditorGUILayout.BeginBoxGroup(attribute.name, GUILayout.MinWidth(0));
        }

        public override void EndPropertyGroup()
        {
            LucidEditorGUILayout.EndBoxGroup();
            LucidEditorGUILayout.EndLayoutIndent();
            
            EditorGUILayout.Space(2);
        }
    }
}