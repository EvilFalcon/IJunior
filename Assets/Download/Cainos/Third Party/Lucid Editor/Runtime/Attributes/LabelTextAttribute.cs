using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class LabelTextAttribute : Attribute
    {
        public readonly string label;

        public LabelTextAttribute(string label)
        {
            this.label = label;
        }
    }
}