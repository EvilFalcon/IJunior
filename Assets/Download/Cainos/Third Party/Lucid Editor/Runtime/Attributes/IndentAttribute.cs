using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class IndentAttribute : Attribute
    {
        public readonly int indent;

        public IndentAttribute()
        {
            this.indent = 1;
        }
        
        public IndentAttribute(int indent)
        {
            this.indent = indent;
        }
    }
}