using System;

namespace Harmony
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public sealed class InjectAttribute : Attribute
    {
    }
}
