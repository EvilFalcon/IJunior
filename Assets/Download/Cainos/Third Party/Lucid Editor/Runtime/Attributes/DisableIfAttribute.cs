using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class DisableIfAttribute : Attribute
    {
        public readonly string condition;

        public DisableIfAttribute(string condition)
        {
            this.condition = condition;
        }
    }
}