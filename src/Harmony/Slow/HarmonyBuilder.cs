using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Harmony.Core;
using Logger;
using Logger.Provider;

namespace Harmony.Slow
{
    public class HarmonyBuilder<TComponent, TModule>
        where TComponent : class
        where TModule : class
    {
        private readonly ILogger _logger;
        private readonly InstanceProvider _provider;
        private readonly ProxyGenerator _proxyGenerator;

        public HarmonyBuilder()
        {
            _logger = new ColorfulConsole();
            _provider = new InstanceProvider(_logger);
            _proxyGenerator = new ProxyGenerator();
        }

        public HarmonyBuilder<TComponent, TModule> AddModule(TModule module)
        {
            var moduleType = typeof(TModule);
            foreach (var providerMethod in moduleType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.GetCustomAttribute<ProvidesAttribute>() != null))
            {
                if (providerMethod.ReturnType == typeof(void))
                {
                    _logger.Verbose($"Skipping void method {providerMethod.Name} of {moduleType.Name} module");

                    continue;
                }

                _provider.AddProvider(module, providerMethod);
            }
            return this;
        }

        public TComponent Build()
        {
            IInterceptor interceptor = new HarmonyEmulator(_logger, _provider);
            return _proxyGenerator.CreateInterfaceProxyWithoutTarget<TComponent>(interceptor);
        }
    }
}
