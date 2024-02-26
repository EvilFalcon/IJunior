using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true)]
    public class TitleHeaderAttribute : Attribute
    {
        public readonly string title;

        public TitleHeaderAttribute(string title)
        {
            this.title = title;
        }
    }
}