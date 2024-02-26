using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {
        public readonly string label = null;
        public readonly InspectorButtonSize size = InspectorButtonSize.Small;

        public ButtonAttribute() { }

        public ButtonAttribute(string label)
        {
            this.label = label;
        }

        public ButtonAttribute(InspectorButtonSize size)
        {
            this.size = size;
        }

        public ButtonAttribute(string label, InspectorButtonSize size)
        {
            this.label = label;
            this.size = size;
        }
    }
}