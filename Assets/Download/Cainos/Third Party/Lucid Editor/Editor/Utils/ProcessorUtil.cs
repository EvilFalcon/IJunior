using System;
using System.Linq;
using System.Reflection;
using Download.Cainos.Third_Party.Lucid_Editor.Editor.InspectorProperty;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime;
using UnityEditor;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Utils
{
    internal static class ProcessorUtil
    {
        private static Type[] cacheAttributeProcessorTypes;
        private static Type[] cacheGroupProcessorTypes;

        public static PropertyProcessor CreateAttributeProcessor(InspectorProperty.InspectorProperty property, Attribute attribute)
        {
            if (cacheAttributeProcessorTypes == null)
            {
                cacheAttributeProcessorTypes = Assembly.GetAssembly(typeof(PropertyProcessor))
                    .GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(PropertyProcessor)) && !x.IsAbstract)
                    .ToArray();
            }

            foreach (Type t in cacheAttributeProcessorTypes)
            {
                if (t.IsDefined(typeof(CustomAttributeProcessorAttribute), false))
                {
                    CustomAttributeProcessorAttribute a = t.GetCustomAttributes(typeof(CustomAttributeProcessorAttribute), false)[0] as CustomAttributeProcessorAttribute;
                    if (a.type == attribute.GetType())
                    {
                        PropertyProcessor processor = (PropertyProcessor)Activator.CreateInstance(t);
                        processor._attribute = attribute;
                        processor._inspectorProperty = property;
                        return processor;
                    }
                }
            }

            return null;
        }

        public static PropertyGroupProcessor CreateGroupProcessor(InspectorPropertyGroup group, SerializedObject serializedObject, PropertyGroupAttribute attribute)
        {
            if (attribute == null) return null;

            if (cacheGroupProcessorTypes == null)
            {
                cacheGroupProcessorTypes = Assembly.GetAssembly(typeof(PropertyGroupProcessor))
                    .GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(PropertyGroupProcessor)) && !x.IsAbstract)
                    .ToArray();
            }

            foreach (Type t in cacheGroupProcessorTypes)
            {
                if (t.IsDefined(typeof(CustomGroupProcessorAttribute), false))
                {
                    CustomGroupProcessorAttribute a = t.GetCustomAttributes(typeof(CustomGroupProcessorAttribute), false)[0] as CustomGroupProcessorAttribute;

                    if (a.type == attribute.GetType())
                    {
                        PropertyGroupProcessor processor = (PropertyGroupProcessor)Activator.CreateInstance(t);
                        processor._attribute = attribute;
                        processor._group = group;
                        processor.serializedObject = serializedObject;

                        return processor;
                    }
                }
            }

            return null;
        }
    }
}