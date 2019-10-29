using System;
using BizCodeFactory.Extensions;

namespace BizCodeFactory.RuleHandlers
{
    /// <summary>
    /// 数字规则处理器
    /// </summary>
    [RuleHandler("Number", "{Number:true/0000}")]
    public class NumberRuleHandler : IBizCodeRuleHandler
    {
        /// <inheritdoc />
        public string Execute(IBizCodeFactoryContext context, string parameterValue)
        {
            var items = parameterValue.Split('/');

            var format = items[1];
            var isRandom = items[0].Equals("false", StringComparison.CurrentCultureIgnoreCase);

            if (isRandom)
            {
                var newNo = RandomHelper.GetRandom();
                while (newNo == context.CurrentRuleInfo.CurrentNo)
                {
                    newNo = RandomHelper.GetRandom();
                }

                context.CurrentRuleInfo.CurrentNo = newNo;
            }
            else
            {
                if (context.CurrentRuleInfo.LastFactoryDate.HasValue)
                {
                    var lastResetDate = context.CurrentRuleInfo.LastFactoryDate.Value.ToString(context.CurrentRuleInfo.ResetDateFormat);
                    if (DateTime.UtcNow.ToString(context.CurrentRuleInfo.ResetDateFormat) != lastResetDate)
                    {
                        context.CurrentRuleInfo.CurrentNo = 0;
                    }
                }

                context.CurrentRuleInfo.CurrentNo += (context.CurrentRuleInfo.NoStep ?? 1);
            }

            var result = context.CurrentRuleInfo.CurrentNo;

            return result.ToString(format);
        }
    }
}