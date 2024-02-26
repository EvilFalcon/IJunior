using Download.Cainos.Third_Party.Lucid_Editor.Editor.Extensions;
using Download.Cainos.Third_Party.Lucid_Editor.Editor.Utils;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(OnValueChangedAttribute))]
    public class OnValueChangedAttributeProcessor : PropertyProcessor
    {
        public override void OnAfterDrawProperty()
        {
            if (property.changed)
            {
                OnValueChangedAttribute onValueChanged = (OnValueChangedAttribute)attribute;
                ReflectionUtil.Invoke(property.parentObject, onValueChanged.methodName, property.serializedProperty.GetValue<object>());
            }
        }
    }
}
