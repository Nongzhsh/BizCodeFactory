using System;
using System.Text;
using System.Threading.Tasks;
using BizCodeFactory.Extensions;

namespace BizCodeFactory
{
    /// <inheritdoc />
    public class BizCodeFactory : IBizCodeFactory
    {
        /// <inheritdoc />
        public IBizCodeFactoryContext Context { get; }

        public BizCodeFactory(IBizCodeFactoryContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        public async Task<string> CreateAsync(int? tenantId, string ruleName)
        {
            await Context.InitAsync(tenantId, ruleName);

            var items = RuleAnalysis.Execute(Context.CurrentRuleInfo.Value);

            var sb = new StringBuilder();
            foreach (var item in items)
            {
                var (handlerName, parameterValue) = RuleAnalysis.GetProperties(item);
                if (Context.Handlers.TryGetValue(handlerName, out var handler))
                {
                    sb.Append(handler.Execute(Context, parameterValue));
                }
            }

            Context.CurrentRuleInfo.CurrentCode = sb.ToString();
            Context.CurrentRuleInfo.LastFactoryDate = DateTime.UtcNow;
            await Context.RuleStore.UpdateAsync(Context.CurrentRuleInfo);

            return Context.CurrentRuleInfo.CurrentCode;
        }

        /// <inheritdoc />
        public void SetVariable(object value)
        {
            var properties = value.GetType().GetProperties();
            foreach (var property in properties)
            {
                SetVariable(property.Name, value.GetValueByPath(property.PropertyType, property.Name));
            }
        }

        /// <inheritdoc />
        public void SetVariable(string variableName, object value)
        {
            Context.Variables[variableName] = value;
        }
    }
}