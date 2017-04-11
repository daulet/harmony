using System;

namespace Harmony
{
    [AttributeUsage(AttributeTargets.Interface)]
    public sealed class ComponentAttribute : Attribute
    {
        private readonly Type[] _modules;

        public ComponentAttribute(params Type[] modules)
        {
            _modules = modules;
        }
    }
}