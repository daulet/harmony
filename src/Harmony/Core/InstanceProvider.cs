using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Logger;

namespace Harmony.Core
{
    internal class InstanceProvider
    {
        private readonly ILogger _logger;
        private readonly Dictionary<Type, Func<object>> _factories;
        private readonly Dictionary<Type, object> _instances;

        public InstanceProvider(ILogger logger)
        {
            _logger = logger;
            _factories = new Dictionary<Type, Func<object>>();
            _instances = new Dictionary<Type, object>();
        }

        public void AddProvider(object providerInstance, MethodInfo method)
        {
            Func<object> factory = () =>
            {
                var parameters = new List<object>();
                foreach (var parameterInfo in method.GetParameters())
                {
                    parameters.Add(GetInstance(parameterInfo.ParameterType));
                }
                return method.Invoke(providerInstance, parameters.ToArray());
            };

            var parameterInfos = method.GetParameters();
            if (parameterInfos.Length > 0)
            {
                _logger.Verbose($"{method.ReturnType.Name} depends on {string.Join(", ", method.GetParameters().Select(x => x.ParameterType.Name))}");
            }
            else
            {
                _logger.Verbose($"{method.ReturnType.Name} has no dependencies");
            }

            _factories.Add(method.ReturnType, factory);
        }

        public object GetInstance(Type type)
        {
            if (!_instances.ContainsKey(type))
            {
                _instances[type] = GetInstanceFactory(type)();
            }
            return _instances[type];
        }

        private Func<object> GetInstanceFactory(Type type)
        {
            if (!_factories.ContainsKey(type))
            {
                _logger.Verbose($"No provider found for type {type.Name}");

                var constructor = type.GetConstructors()
                    .Where(x => x.CustomAttributes
                        .OfType<CustomAttributeData>()
                        .Any(y => y.AttributeType == typeof(InjectAttribute)))
                    .SingleOrDefault();

                if (constructor != null)
                {
                    _logger.Verbose($"Found injectable constructor for type {type.Name}");

                    Func<object> factory = () =>
                    {
                        var parameters = new List<object>();
                        foreach (var parameterInfo in constructor.GetParameters())
                        {
                            parameters.Add(GetInstance(parameterInfo.ParameterType));
                        }
                        return constructor.Invoke(parameters.ToArray());
                    };
                    _factories.Add(type, factory);
                }
                else
                {
                    _logger.Info($"Did not find injectable constructor for type {type.Name}");
                }
            }

            return _factories[type];
        }
    }
}