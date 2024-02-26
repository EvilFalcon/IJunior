using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(LabelWidthAttribute))]
    public class LabelWidthAttributeProcessor : PropertyProcessor
    {
        private float defaultWidth;

        public override void OnBeforeDrawProperty()
        {
            defaultWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = ((LabelWidthAttribute)attribute).width;
        }

        public override void OnAfterDrawProperty()
        {
            EditorGUIUtility.labelWidth = defaultWidth;
        }
    }
}