namespace Harmony.Samples.InjectionUsingHarmony
{
    [Module]
    public class DripCoffeeModule
    {
        [Provides]
        public IHeater ProvideHeater()
        {
            return new ElectricHeater();
        }

        [Provides]
        public IPump ProvidePump(Thermosiphon pump)
        {
            return pump;
        }
    }
}