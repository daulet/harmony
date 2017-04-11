using System;

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

        public void Pump()
        {
            if (_heater.IsHot())
            {
                Console.WriteLine("=> => pumping => =>");
            }
        }
    }
}