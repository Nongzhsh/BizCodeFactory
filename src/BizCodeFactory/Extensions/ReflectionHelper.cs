using System;
using System.Diagnostics;

namespace BizCodeFactory.Extensions
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Gets value of a property by it's full path from given object
        /// </summary>
        public static object GetValueByPath(this object obj, Type objectType, string propertyPath)
        {
            var value = obj;
            var currentType = objectType;
            var objectPath = currentType.FullName;
            var absolutePropertyPath = propertyPath;

            Debug.Assert(objectPath != null, nameof(objectPath) + " != null");
            if (absolutePropertyPath.StartsWith(objectPath))
            {
                absolutePropertyPath = absolutePropertyPath.Replace(objectPath + ".", "");
            }

            foreach (var propertyName in absolutePropertyPath.Split('.'))
            {
                var property = currentType.GetProperty(propertyName);
                value = property.GetValue(value, null);
                currentType = property.PropertyType;
            }

            return value;
        }
    }
}