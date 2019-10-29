using System;
using System.Collections.Generic;
using System.Text;

namespace BizCodeFactory
{
    /// <summary>
    /// 规则分析
    /// </summary>
    public class RuleAnalysis
    {
        [ThreadStatic]
        private static Stack<char> stack;

        /// <summary>
        /// 分析给定的规则
        /// </summary>
        /// <param name="rule">完整规则</param>
        /// <returns>规则项集合（每一项都不包含最外层的大括号）</returns>
        public static string[] Execute(string rule)
        {
            var items = new List<string>();
            var sb = new StringBuilder();
            if (stack == null)
            {
                stack = new Stack<char>();
            }
            stack.Clear();
            foreach (var c in rule)
            {
                if (c == '{')
                {
                    if (stack.Count > 0)
                    {
                        sb.Append(c);
                    }
                    stack.Push(c);
                }
                else if (c == '}')
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        items.Add(sb.ToString());
                        sb.Clear();
                    }
                    else
                        sb.Append(c);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return items.ToArray();
        }

        /// <summary>
        /// 获取规则详情
        /// </summary>
        /// <param name="ruleContent">规则内容</param>
        /// <returns></returns>
        public static (string, string) GetProperties(string ruleContent)
        {
            var index = ruleContent.IndexOf(':');
            var handlerName = ruleContent.Substring(0, index);
            var parameterValue = ruleContent.Substring(index + 1, ruleContent.Length - index - 1);

            return (handlerName, parameterValue);
        }
    }
}
