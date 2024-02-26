using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class HideIfAttribute : Attribute
    {
        public readonly string condition;

        public HideIfAttribute(string condition)
        {
            this.condition = condition;
        }
    }
}