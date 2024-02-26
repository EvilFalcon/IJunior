using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true)]
    public class BlockquoteAttribute : Attribute
    {
        public readonly string text;

        public BlockquoteAttribute(string text)
        {
            this.text = text;
        }
    }
}