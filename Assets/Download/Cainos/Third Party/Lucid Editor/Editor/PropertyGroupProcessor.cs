using System;
using Download.Cainos.Third_Party.Lucid_Editor.Editor.InspectorProperty;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor
{
    public abstract class PropertyGroupProcessor
    {
        public PropertyGroupAttribute attribute => _attribute;
        internal PropertyGroupAttribute _attribute;

        public InspectorPropertyGroup group => _group;
        internal InspectorPropertyGroup _group;

        internal SerializedObject serializedObject;

        public LocalPersistentData<T> GetLocalPersistentData<T>(string id)
        {
            return LucidEditorPrefs.CreateLocalPersistentData<T>
            (
                "LucidEditor_PropertyGroupProcessor_" +
                    GlobalObjectId.GetGlobalObjectIdSlow(serializedObject.targetObject) + "_" +
                    attribute.GetType().Name + "_" +
                    attribute.path + "_" + 
                    id
            );
        }

        public virtual void Initialize() { }
        public virtual void BeginPropertyGroup() { }
        public virtual void EndPropertyGroup() { }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CustomGroupProcessorAttribute : Attribute
    {
        public readonly Type type;
        public CustomGroupProcessorAttribute(Type type)
        {
            this.type = type;
        }
    }
}