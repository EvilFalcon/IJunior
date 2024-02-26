using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(PropertyOrderAttribute))]
    public class PropertyOrderAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeInspectorGUI()
        {
            PropertyOrderAttribute propertyOrder = (PropertyOrderAttribute)attribute;
            property.order = propertyOrder.propertyOrder;
        }
    }
}