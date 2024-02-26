using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(IndentAttribute))]
    public class IndentAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            IndentAttribute indent = (IndentAttribute)attribute;
            property.indent = indent.indent;
        }
    }
}