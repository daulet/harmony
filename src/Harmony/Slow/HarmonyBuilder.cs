using System;

namespace Harmony.Slow
{
    public class HarmonyBuilder<TComponent, TModule>
        where TComponent : class
        where TModule : class
    {
        public HarmonyBuilder<TComponent, TModule> AddModule(TModule module)
        {
            return this;
        }

        public TComponent Build()
        {
            throw new NotImplementedException();
        }
    }
}
