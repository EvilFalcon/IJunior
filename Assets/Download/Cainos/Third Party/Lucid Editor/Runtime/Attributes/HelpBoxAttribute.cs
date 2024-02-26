using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true)]
    public class HelpBoxAttribute : Attribute
    {
        public readonly string message;
        public readonly HelpBoxMessageType type;

        public HelpBoxAttribute(string message)
        {
            this.message = message;
            this.type = HelpBoxMessageType.Info;
        }

        public HelpBoxAttribute(string message, HelpBoxMessageType type)
        {
            this.message = message;
            this.type = type;
        }
    }

    public enum HelpBoxMessageType
    {
        None,
        Info,
        Warning,
        Error
    }
}