namespace Harmony.Samples.InjectionUsingHarmony
{
    public class Thermosiphon : IPump
    {
        private readonly IHeater _heater;

        [Inject]
        public Thermosiphon(IHeater heater)
        {
            _heater = heater;
        }
    }
}