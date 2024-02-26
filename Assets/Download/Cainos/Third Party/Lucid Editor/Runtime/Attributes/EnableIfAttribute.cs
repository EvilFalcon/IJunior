using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class EnableIfAttribute : Attribute
    {
        public readonly string condition;

        public EnableIfAttribute(string condition)
        {
            this.condition = condition;
        }
    }
}