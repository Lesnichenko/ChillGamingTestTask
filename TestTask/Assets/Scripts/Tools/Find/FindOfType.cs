using System;
using System.Collections.Generic;

namespace Tools.Find
{
    public static class FindOfType
    {
        private static readonly Type[] _allTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
        
        public static List<Type> GetSubclassListThroughHierarchy<T>(bool inclusiveAbstract = true)
        {
            return GetSubclassListThroughHierarchy(typeof(T), inclusiveAbstract);
        }

        private static List<Type> GetSubclassListThroughHierarchy(Type type, bool inclusiveAbstract = true)
        {
            if(type == null) throw new Exception("FindByType(GetSubclassListThroughHierarchy): Type is null");
            
            var result = new List<Type>();

            for (int i = 0; i < _allTypes.Length; i++)
            {
                if ((inclusiveAbstract || !_allTypes[i].IsAbstract) && IsSubclass(type, _allTypes[i]))
                {
                    result.Add(_allTypes[i]);
                }
            }

            return result;
        }

        private static bool IsSubclass(Type baseType, Type subclassType)
        {
            if (baseType == null) throw new ArgumentNullException(nameof(baseType));
            if (subclassType == null) throw new ArgumentNullException(nameof(subclassType));

            if (baseType.IsInterface)
            {
                return subclassType.GetInterface(baseType.Name) != null; 
            }
            else
            {
                var typeToCheck = subclassType.BaseType;
                
                while (typeToCheck != null)
                {
                    if (typeToCheck == baseType) return true;
                    typeToCheck = typeToCheck.BaseType;
                }

                return false;
            }
        }
    }
}