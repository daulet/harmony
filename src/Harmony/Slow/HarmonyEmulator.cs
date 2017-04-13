using Castle.DynamicProxy;
using Harmony.Core;
using Logger;

namespace Harmony.Slow
{
    internal class HarmonyEmulator : IInterceptor
    {
        private readonly ILogger _logger;
        private readonly InstanceProvider _provider;

        public HarmonyEmulator(ILogger logger, InstanceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.ReturnType == typeof(void))
            {
                _logger.Error($"{invocation.Method.Name} has no return type.");
            }

            invocation.ReturnValue = _provider.GetInstance(invocation.Method.ReturnType);
        }
    }
}
