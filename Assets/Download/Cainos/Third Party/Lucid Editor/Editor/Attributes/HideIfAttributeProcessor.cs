using Download.Cainos.Third_Party.Lucid_Editor.Editor.Utils;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(HideIfAttribute))]
    public class HideIfAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            HideIfAttribute hideIf = (HideIfAttribute)attribute;
            property.isHidden |= ReflectionUtil.GetValueBool(property.parentObject, hideIf.condition);
        }
    }
}