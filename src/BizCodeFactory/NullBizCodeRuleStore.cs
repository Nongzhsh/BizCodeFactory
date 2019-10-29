using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizCodeFactory
{
    /// <summary>
    /// <see cref="IBizCodeRuleStore"/> 的空实现
    /// </summary>
    public class NullBizCodeRuleStore : IBizCodeRuleStore
    {
        /// <inheritdoc />
        public Task<RuleInfo> GetRuleAsync(int? tenantId, string name)
        {
            return Task.FromResult((RuleInfo)null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(RuleInfo rule)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task CreateAsync(RuleInfo rule)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task UpdateAsync(RuleInfo rule)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<List<RuleInfo>> GetAllListAsync(int? tenantId)
        {
            return Task.FromResult((List<RuleInfo>)null);
        }
    }
}