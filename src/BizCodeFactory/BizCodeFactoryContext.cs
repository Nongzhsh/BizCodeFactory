using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizCodeFactory
{
    /// <inheritdoc />
    public class BizCodeFactoryContext : IBizCodeFactoryContext
    {
        /// <inheritdoc />
        public Dictionary<string, IBizCodeRuleHandler> Handlers { get; }

        /// <inheritdoc />
        public IBizCodeRuleStore RuleStore { get; }

        /// <inheritdoc />
        public RuleInfo CurrentRuleInfo { get; private set; }

        /// <inheritdoc />
        public Variables Variables { get; }

        public BizCodeFactoryContext(IBizCodeRuleStore ruleStore)
        {
            RuleStore = ruleStore;
            Variables = new Variables();
            Handlers = new Dictionary<string, IBizCodeRuleHandler>();
        }

        /// <inheritdoc />
        public async Task InitAsync(int? tenantId, string ruleName)
        {
            CurrentRuleInfo = await RuleStore.GetRuleAsync(tenantId, ruleName);
        }

        /// <inheritdoc />
        public T GetVariable<T>(string name) => Variables.GetVariable<T>(name);

        /// <inheritdoc />
        public object GetVariable(string name) => Variables.GetVariable(name);
    }
}