using System;

namespace BizCodeFactory.RuleHandlers
{
    /// <summary>
    /// Guid 规则处理器
    /// </summary>
    [RuleHandler("Guid", "{Guid:N}")]
    public class GuidRuleHandler : IBizCodeRuleHandler
    {
        /// <inheritdoc />
        public string Execute(IBizCodeFactoryContext context, string parameterValue)
        {
            var result = Guid.NewGuid().ToString(parameterValue);
            return result;
        }
    }
}