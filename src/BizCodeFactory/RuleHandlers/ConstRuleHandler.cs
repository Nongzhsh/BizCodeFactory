namespace BizCodeFactory.RuleHandlers
{
    /// <summary>
    /// 常量规则处理器
    /// </summary>
    [RuleHandler("Const", "{Const:ConstValue}")]
    public class ConstRuleHandler : IBizCodeRuleHandler
    {
        /// <inheritdoc />
        public string Execute(IBizCodeFactoryContext context, string parameterValue)
        {
            var result = parameterValue;
            return result;
        }
    }
}