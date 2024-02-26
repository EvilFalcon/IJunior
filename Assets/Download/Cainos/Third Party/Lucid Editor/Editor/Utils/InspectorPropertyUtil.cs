using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Download.Cainos.Third_Party.Lucid_Editor.Editor.Extensions;
using Download.Cainos.Third_Party.Lucid_Editor.Editor.InspectorProperty;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime;
using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Utils
{
    internal static class InspectorPropertyUtil
    {
        public static IEnumerable<InspectorProperty.InspectorProperty> CreateProperties(SerializedObject serializedObject)
        {
            var list = new List<InspectorProperty.InspectorProperty>();
            SerializedProperty iterator = serializedObject.GetIterator();

            iterator.NextVisible(true);
            while (iterator.NextVisible(false))
            {
                InspectorField ip = new InspectorField(iterator.Copy(), iterator.GetAttributes<Attribute>(true));
                list.Add(ip);
            }

            list.AddRange(CreateEditableProperties(serializedObject, serializedObject.targetObject));
            list.AddRange(CreateButtonsAndNonSerializedProperties(serializedObject, serializedObject.targetObject));

            return list;
        }

        public static IEnumerable<InspectorProperty.InspectorProperty> CreateChildProperties(InspectorField property)
        {
            var list = new List<InspectorProperty.InspectorProperty>();

            if (property.serializedProperty.hasVisibleChildren &&
                (property.serializedProperty.propertyType == SerializedPropertyType.Generic || property.serializedProperty.propertyType == SerializedPropertyType.ManagedReference) &&
                !property.serializedProperty.isArray &&
                !TypeUtil.HasCustomDrawerType(TypeUtil.GetType(property.serializedProperty.type)))
            {
                var iterator = property.serializedProperty.Copy();

                iterator.NextVisible(true);
                int depth = iterator.depth;
                list.Add(new InspectorField(iterator.Copy(), iterator.GetAttributes<Attribute>(true)));

                while (iterator.NextVisible(false))
                {
                    if (iterator.depth != depth) break;
                    list.Add(new InspectorField(iterator.Copy(), iterator.GetAttributes<Attribute>(true)));
                }

                object obj = property.serializedProperty.GetValue<object>();
                list.AddRange(CreateButtonsAndNonSerializedProperties(property.serializedProperty.serializedObject, obj));
            }

            return list;
        }

        public static IEnumerable<InspectorProperty.InspectorProperty> CreateButtonsAndNonSerializedProperties(SerializedObject serializedObject, object targetObject)
        {
            var list = new List<InspectorProperty.InspectorProperty>();

            foreach (MemberInfo memberInfo in ReflectionUtil.GetAllMembers(targetObject.GetType(), (BindingFlags)(-1), inherit: true))
            {
                //field
                if (memberInfo is FieldInfo fieldInfo)
                {
                    if (fieldInfo.IsPublic || fieldInfo.GetCustomAttribute<SerializeField>() == null)
                    {
                        ShowInInspectorAttribute showInInspector = fieldInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                        if (showInInspector != null)
                        {
                            list.Add(new NonSerializedInspectorProperty(serializedObject, targetObject, fieldInfo.Name, fieldInfo.GetCustomAttributes().ToArray()));
                        }
                    }
                }
                //property
                //modified: property is now handled in CreateEditableProperties to support editing
                //else if (memberInfo is PropertyInfo propertyInfo)
                //{
                //    MethodInfo getterInfo = propertyInfo.GetGetMethod();
                //    if (getterInfo != null)
                //    {
                //        if (getterInfo.IsPublic || propertyInfo.GetCustomAttribute<SerializeField>() == null)
                //        {
                //            ShowInInspectorAttribute showInInspector = propertyInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                //            if (showInInspector != null)
                //            {
                //                list.Add(new NonSerializedInspectorProperty(serializedObject, targetObject, propertyInfo.Name, propertyInfo.GetCustomAttributes().ToArray()));
                //            }
                //        }
                //    }
                //}


                //method
                else if (memberInfo is MethodInfo methodInfo)
                {
                    ShowInInspectorAttribute showInInspector = methodInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                    if (showInInspector != null)
                    {
                        list.Add(new NonSerializedInspectorProperty(serializedObject, targetObject, methodInfo.Name, methodInfo.GetCustomAttributes().ToArray()));
                    }

                    ButtonAttribute buttonAttribute = methodInfo.GetCustomAttribute<ButtonAttribute>();
                    if (buttonAttribute != null)
                    {
                        InspectorButton ib;
                        if (string.IsNullOrEmpty(buttonAttribute.label))
                        {
                            ib = new InspectorButton(serializedObject, serializedObject.targetObject, methodInfo, buttonAttribute.size);
                        }
                        else
                        {
                            ib = new InspectorButton(serializedObject, serializedObject.targetObject, methodInfo, buttonAttribute.label, buttonAttribute.size);
                        }
                        list.Add(ib);
                    }
                }
            }

            return list;
        }

        //draw editable property
        public static IEnumerable<InspectorProperty.InspectorProperty> CreateEditableProperties(SerializedObject serializedObject, object targetObject)
        {
            var list = new List<InspectorProperty.InspectorProperty>();

            foreach (MemberInfo memberInfo in ReflectionUtil.GetAllMembers(targetObject.GetType(), (BindingFlags)(-1), inherit: true))
            {
                if (memberInfo is PropertyInfo propertyInfo)
                {
                    MethodInfo getterInfo = propertyInfo.GetGetMethod();
                    if (getterInfo != null)
                    {
                        ShowInInspectorAttribute showInInspector = propertyInfo.GetCustomAttribute<ShowInInspectorAttribute>();
                        if (showInInspector != null)
                        {
                            list.Add(new EditableInspectorProperty(serializedObject, targetObject, propertyInfo.Name, propertyInfo.GetCustomAttributes().ToArray()));
                        }
                    }
                }
            }

            return list;
        }

        public static IEnumerable<InspectorProperty.InspectorProperty> GroupProperties(IEnumerable<InspectorProperty.InspectorProperty> properties)
        {
            List<List<InspectorProperty.InspectorProperty>> groupList = new List<List<InspectorProperty.InspectorProperty>>();

            List<InspectorProperty.InspectorProperty> propertyList = new List<InspectorProperty.InspectorProperty>(properties);
            List<InspectorProperty.InspectorProperty> usedProperties = new List<InspectorProperty.InspectorProperty>();

            Dictionary<InspectorProperty.InspectorProperty, List<PropertyGroupAttribute>> paDictionary = new Dictionary<InspectorProperty.InspectorProperty, List<PropertyGroupAttribute>>();
            foreach (InspectorProperty.InspectorProperty property in propertyList)
            {
                paDictionary.Add(property, new List<PropertyGroupAttribute>());
                paDictionary[property].AddRange(
                    property.attributes
                        .Where(x => x is PropertyGroupAttribute)
                        .Select(x => (PropertyGroupAttribute)x)
                );
            }

            int depth = 0;
            while (propertyList.Count > 0)
            {
                groupList.Add(new List<InspectorProperty.InspectorProperty>());

                foreach (InspectorProperty.InspectorProperty property in propertyList)
                {
                    PropertyGroupAttribute attribute = paDictionary[property].FirstOrDefault(x => x.groupDepth == depth);

                    if (attribute != null)
                    {
                        string[] hierarchy = attribute.path.Split('/');
                        string currentPath = string.Empty;
                        InspectorPropertyGroup group = null;

                        for (int i = 0; i < hierarchy.Length; i++)
                        {
                            currentPath += hierarchy[i];

                            InspectorPropertyGroup newGroup = groupList[i]
                                .Where(x => x is InspectorPropertyGroup)
                                .Select(x => (InspectorPropertyGroup)x)
                                .FirstOrDefault(x => x.path.Split('/')[i] == hierarchy[i]);

                            if (newGroup == null)
                            {
                                newGroup = new InspectorPropertyGroup(currentPath, property.serializedObject, attribute);
                                groupList[i].Add(newGroup);
                                group?.Add(newGroup);
                            }

                            group = newGroup;
                            currentPath += '/';
                        }

                        paDictionary[property].RemoveAll(x => x.groupDepth == depth);
                        if (paDictionary[property].Count == 0)
                        {
                            group.Add(property);
                            usedProperties.Add(property);
                        }
                    }
                    else if (paDictionary[property].Count == 0)
                    {
                        groupList[0].Add(property);
                        usedProperties.Add(property);
                    }
                }

                foreach (InspectorProperty.InspectorProperty property in usedProperties)
                {
                    propertyList.Remove(property);
                }
                usedProperties.Clear();
                depth++;
            }

            return groupList.Count > 0 ? groupList[0] : new List<InspectorProperty.InspectorProperty>();
        }

    }

}