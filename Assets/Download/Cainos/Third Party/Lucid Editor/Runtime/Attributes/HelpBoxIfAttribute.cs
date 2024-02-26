using System;

namespace Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true)]
    public class HelpBoxIfAttribute : Attribute
    {
        public readonly string condition;
        public readonly string message;
        public readonly HelpBoxMessageType type;

        public HelpBoxIfAttribute(string condition, string message)
        {
            this.condition = condition;
            this.message = message;
            this.type = HelpBoxMessageType.Info;
        }

        public HelpBoxIfAttribute(string condition, string message, HelpBoxMessageType type)
        {
            this.condition = condition;
            this.message = message;
            this.type = type;
        }
    }
}