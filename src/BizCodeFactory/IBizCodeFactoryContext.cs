using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizCodeFactory
{
    /// <summary>
    /// 用于编码生成的上下文。
    /// </summary>
    public interface IBizCodeFactoryContext
    {
        /// <summary>
        /// 规则处理器
        /// </summary>
        Dictionary<string, IBizCodeRuleHandler> Handlers { get; }

        /// <summary>
        /// IBizCodeRuleStore
        /// </summary>
        IBizCodeRuleStore RuleStore { get; }

        /// <summary>
        /// 当前规则信息
        /// </summary>
        RuleInfo CurrentRuleInfo { get; }

        /// <summary>
        /// 执行过程变量
        /// </summary>
        Variables Variables { get; }

        /// <summary>
        /// 初始化上下文
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        /// <param name="ruleName">规则名称</param>
        Task InitAsync(int? tenantId, string ruleName);

        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="name">变量名</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetVariable<T>(string name);

        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="name">变量名</param>
        /// <returns></returns>
        object GetVariable(string name);
    }
}