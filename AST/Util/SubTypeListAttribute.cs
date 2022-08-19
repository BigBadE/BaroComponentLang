using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Language.Util
{
    /// <summary>
    /// Gets all the subtypes of a type and adds it to a list,
    /// then sets the field of this attribute to that list.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SubTypeListAttribute : Attribute
    {
        private static bool _inited = false;

        private readonly Type _target;

        public SubTypeListAttribute(Type target)
        {
            _target = target;
        }

        public static bool IsInited() => _inited;

        public static void InitSubTypeLists()
        {
            _inited = true;
            Dictionary<Type, List<Type>> targets = new();
            
            Dictionary<Type, List<FieldInfo>> fields = GetFields(ref targets);
            //Find all types and their needed extenders/interfaces
            foreach (Type type in typeof(SubTypeListAttribute).Assembly.GetTypes())
            {
                Type testing = type;

                while (testing != null && testing != typeof(object) && !testing.IsAbstract && !testing.IsInterface)
                {
                    if (targets.ContainsKey(testing))
                    {
                        targets[testing].Add(type);
                    }

                    foreach (Type interfaceType in testing.GetInterfaces())
                    {
                        if (targets.ContainsKey(interfaceType))
                        {
                            targets[interfaceType].Add(type);
                        }
                    }


                    if (testing.BaseType != null && targets.ContainsKey(testing.BaseType))
                    {
                        targets[testing.BaseType].Add(type);
                    }

                    testing = testing.BaseType;
                }
            }

            //Loop over every type with sublist fields and set their value
            foreach (var (key, foundFields) in fields)
            {
                foreach (FieldInfo fieldInfo in foundFields)
                {
                    fieldInfo.SetValue(null, targets[key].Select(type => ExpressionFactory.Wrap(type)));
                }
            }
        }

        private static Dictionary<Type, List<FieldInfo>> GetFields(ref Dictionary<Type, List<Type>> targets)
        {
            Dictionary<Type, List<FieldInfo>> fields = new();

            foreach (FieldInfo field in
                typeof(SubTypeListAttribute).Assembly.GetTypes().SelectMany(found => found.GetFields()))
            {
                SubTypeListAttribute found = field.GetCustomAttribute<SubTypeListAttribute>();
                if (found == null)
                {
                    continue;
                }

                if (fields.TryGetValue(found._target, out var output))
                {
                    output.Add(field);
                }
                else
                {
                    fields[found._target] = new List<FieldInfo> {field};
                    targets[found._target] = new List<Type>();
                }
            }

            return fields;
        }
    }
}