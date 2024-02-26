using Download.Cainos.Third_Party.Lucid_Editor.Editor.Extensions;
using Download.Cainos.Third_Party.Lucid_Editor.Editor.Utils;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(ValidateInputAttribute))]
    public class ValidateInputAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            ValidateInputAttribute validateInput = (ValidateInputAttribute)attribute;
            if (!ReflectionUtil.InvokeBool(property.parentObject, validateInput.condition, property.serializedProperty.GetValue<object>()))
            {
                EditorGUILayout.HelpBox(validateInput.message == null ? $"{property.displayName} is not valid." : validateInput.message, (MessageType)validateInput.type);
            }
        }
    }
}
