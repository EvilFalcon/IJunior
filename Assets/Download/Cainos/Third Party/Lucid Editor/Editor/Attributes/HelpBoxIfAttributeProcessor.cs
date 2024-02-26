using Download.Cainos.Third_Party.Lucid_Editor.Editor.Utils;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(HelpBoxIfAttribute))]
    public class HelpBoxIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            HelpBoxIfAttribute helpBoxIf = (HelpBoxIfAttribute)attribute;
            if (ReflectionUtil.GetValueBool(property.parentObject, helpBoxIf.condition))
            {
                EditorGUILayout.HelpBox(helpBoxIf.message, (MessageType)helpBoxIf.type);
            }
        }
    }
}