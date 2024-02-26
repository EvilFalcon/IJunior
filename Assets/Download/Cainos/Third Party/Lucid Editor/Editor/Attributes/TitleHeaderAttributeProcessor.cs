using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(TitleHeaderAttribute))]
    public class TitleHeaderAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            EditorGUILayout.Space(7);
            LucidEditorGUILayout.TitleHeader(((TitleHeaderAttribute)attribute).title);
        }
    }
}