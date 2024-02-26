using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(ReadOnlyAttribute))]
    public class ReadOnlyAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            property.isEditable = false;
        }
    }
}