using System.Threading.Tasks;

namespace BizCodeFactory
{
    /// <summary>
    /// 业务编码生成器
    /// </summary>
    public interface IBizCodeFactory
    {
        /// <summary>
        /// 上下文
        /// </summary>
        IBizCodeFactoryContext Context { get; }


        /// <summary>
        /// 创建编码
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        /// <param name="ruleName">规则名称</param>
        Task<string> CreateAsync(int? tenantId, string ruleName);

        /// <summary>
        /// 设置变量
        /// </summary>
        /// <param name="value">值</param>
        void SetVariable(object value);

        /// <summary>
        /// 设置变量
        /// </summary>
        /// <param name="variableName">变量名</param>
        /// <param name="value">值</param>
        void SetVariable(string variableName, object value);
    }
}