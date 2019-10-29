using System;
using System.Linq;

namespace BizCodeFactory
{
    /// <summary>
    /// 规则处理器特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RuleHandlerAttribute : Attribute
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="name"> </param>
        /// <param name="description"> </param>
        public RuleHandlerAttribute(string name, string description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
            Description = description;
        }

        /// <summary>
        /// 处理器名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取说明
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetDescription<T>()
        {
            return GetDescription(typeof(T));
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetName<T>()
        {
            return GetName(typeof(T));
        }

        /// <summary>
        /// 获取说明
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDescription(Type type)
        {
            var attribute = GetRuleHandlerAttribute(type) ??
                            throw new InvalidCastException(
                                $"RuleHandlerType: {type.Name} is not annotation of {nameof(RuleHandlerAttribute)}!");

            return attribute.Description;
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetName(Type type)
        {
            var attribute = GetRuleHandlerAttribute(type) ??
                            throw new InvalidCastException(
                                $"RuleHandlerType: {type.Name} is not annotation of {nameof(RuleHandlerAttribute)}!");

            return attribute.Name;
        }

        /// <summary>
        /// 获取类型的 RuleHandlerAttribute
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static RuleHandlerAttribute GetRuleHandlerAttribute(Type type)
        {
            if (!IsRuleHandler(type))
                throw new InvalidCastException(
                    $"type:{type.Name} is not AssignableFrom typeOf {nameof(IBizCodeRuleHandler)}!");

            var attribute = type
                .GetCustomAttributes(true)
                .OfType<RuleHandlerAttribute>()
                .FirstOrDefault();

            return attribute;
        }

        /// <summary>
        /// 判断给定类型是否是编码规则处理器
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsRuleHandler(Type type)
        {
            return typeof(IBizCodeRuleHandler).IsAssignableFrom(type);
        }
    }
}