namespace BizCodeFactory.RuleHandlers
{
    /// <summary>
    /// 变量规则处理器
    /// </summary>
    [RuleHandler("Variable", "{Variable:Name}")]
    public class VariableRuleHandler : IBizCodeRuleHandler
    {
        /// <inheritdoc />
        public string Execute(IBizCodeFactoryContext context, string parameterValue)
        {
            var result = context.GetVariable(parameterValue).ToString();
            return result;
        }
    }
}