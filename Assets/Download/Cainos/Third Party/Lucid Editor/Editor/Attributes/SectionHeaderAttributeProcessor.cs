using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(SectionHeaderAttribute))]
    public class SectionHeaderAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            EditorGUILayout.Space(7);
            LucidEditorGUILayout.SectionHeader(((SectionHeaderAttribute)attribute).title);
        }
    }
}