using Download.Cainos.Third_Party.Lucid_Editor.Editor.Extensions;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(HorizontalLineAttribute))]
    public class HorizontalLineAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            HorizontalLineAttribute horizontalLine = (HorizontalLineAttribute)attribute;
            
            EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);
            if (horizontalLine.useCustomColor)
            {
                LucidEditorGUILayout.Line(horizontalLine.customColor);
            }
            else
            {
                LucidEditorGUILayout.Line(horizontalLine.color.ToColor());
            }
            EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);
        }
    }
}