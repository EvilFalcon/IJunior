using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true)]
    public class SectionHeaderAttribute : Attribute
    {
        public readonly string title;

        public SectionHeaderAttribute(string title)
        {
            this.title = title;
        }
    }
}