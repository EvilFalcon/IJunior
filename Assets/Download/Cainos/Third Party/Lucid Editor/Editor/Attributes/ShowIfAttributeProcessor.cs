using Download.Cainos.Third_Party.Lucid_Editor.Editor.Utils;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(ShowIfAttribute))]
    public class ShowIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;
            property.isHidden |= !ReflectionUtil.GetValueBool(property.parentObject, showIf.condition);
        }
    }
}