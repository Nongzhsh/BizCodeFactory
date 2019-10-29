using System;

namespace BizCodeFactory.RuleHandlers
{
    /// <summary>
    /// 当前时间处理器
    /// </summary>
    [RuleHandler("Now", "{Now:yyyyMMdd}")]
    public class NowRuleHandler : IBizCodeRuleHandler
    {
        /// <inheritdoc />
        public string Execute(IBizCodeFactoryContext context, string parameterValue)
        {
            var result = DateTime.UtcNow.ToString(parameterValue);
            return result;
        }
    }
}