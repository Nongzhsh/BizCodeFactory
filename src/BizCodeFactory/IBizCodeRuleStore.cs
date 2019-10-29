using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizCodeFactory
{
    /// <summary>
    /// 业务编码规则存储器
    /// </summary>
    public interface IBizCodeRuleStore
    {
        /// <summary>
        /// 根据租户Id和规则名称获取第一条激活的编码规则
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        /// <param name="name">规则名称</param>
        /// <returns></returns>
        Task<RuleInfo> GetRuleAsync(int? tenantId, string name);

        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="rule">待删除规则</param>
        Task DeleteAsync(RuleInfo rule);

        /// <summary>
        /// 添加规则
        /// </summary>
        /// <param name="rule">待添加规则</param>
        Task CreateAsync(RuleInfo rule);

        /// <summary>
        /// 更新规则，如果规则内容发生变更，则当前编码重置为 0
        /// </summary>
        /// <param name="rule">待更新规则</param>
        Task UpdateAsync(RuleInfo rule);

        /// <summary>
        /// 根据租户Id获取全部规则
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        /// <returns>租户的全部规则列表</returns>
        Task<List<RuleInfo>> GetAllListAsync(int? tenantId);
    }
}