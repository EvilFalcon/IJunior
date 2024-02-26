using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredAttribute : Attribute
    {
        public readonly string message = null;
        public RequiredAttribute() { }
        public RequiredAttribute(string message)
        {
            this.message = message;
        }
    }
}