using BizCodeFactory.RuleHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BizCodeFactory.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册业务编码生成器
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBizCodeFactory(this IServiceCollection services)
        {
            services
                .AddTransient<IBizCodeFactoryContext, BizCodeFactoryContext>()
                .AddTransient<IBizCodeRuleStore, NullBizCodeRuleStore>()
                .AddTransient<IBizCodeFactory, BizCodeFactory>()
                .AddBizCodeRuleHandlers();

            return services;
        }

        /// <summary>
        /// 注册编码规则处理器
        /// </summary>
        /// <param name="services"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IServiceCollection AddBizCodeRuleHandler<T>(this IServiceCollection services)
            where T : class, IBizCodeRuleHandler
        {

            return services
                .AddTransient<T>()
                .AddTransient<IBizCodeRuleHandler>(sp =>
                {
                    var handler = sp.GetRequiredService<T>();

                    var context = sp.GetService<IBizCodeFactoryContext>();
                    var name = RuleHandlerAttribute.GetName<T>();
                    context.Handlers.Add(name, handler);

                    return handler;
                });
        }

        private static void AddBizCodeRuleHandlers(this IServiceCollection services)
        {
            services
                .AddBizCodeRuleHandler<ConstRuleHandler>()
                .AddBizCodeRuleHandler<GuidRuleHandler>()
                .AddBizCodeRuleHandler<NowRuleHandler>()
                .AddBizCodeRuleHandler<NumberRuleHandler>()
                .AddBizCodeRuleHandler<VariableRuleHandler>();
        }
    }
}