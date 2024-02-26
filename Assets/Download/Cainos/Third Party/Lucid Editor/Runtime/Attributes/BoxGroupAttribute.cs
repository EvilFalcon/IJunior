using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class BoxGroupAttribute : PropertyGroupAttribute
    {
        public BoxGroupAttribute(string groupName) : base(groupName) { }
    }
}