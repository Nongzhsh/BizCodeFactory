using System.Text;

namespace BizCodeFactory
{
    /// <summary>
    /// 规则处理器
    /// </summary>
    public interface IBizCodeRuleHandler
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="parameterValue">表达式参数值</param>
        string Execute(IBizCodeFactoryContext context, string parameterValue);
    }
}