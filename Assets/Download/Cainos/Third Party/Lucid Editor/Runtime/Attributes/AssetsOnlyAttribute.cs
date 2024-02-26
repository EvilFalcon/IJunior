using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class AssetsOnlyAttribute : Attribute
    {
        public AssetsOnlyAttribute()
        {
        }
    }
}
