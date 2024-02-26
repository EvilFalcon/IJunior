using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class ShowIfAttribute : Attribute
    {
        public readonly string condition;

        public ShowIfAttribute(string condition)
        {
            this.condition = condition;
        }
    }
}