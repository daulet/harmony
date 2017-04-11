using System;

namespace Harmony.Samples.InjectionUsingHarmony
{
    public class CoffeeMaker
    {
        private readonly IHeater _heater;
        private readonly IPump _pump;

        [Inject]
        public CoffeeMaker(IHeater heater, IPump pump)
        {
            _heater = heater;
            _pump = pump;
        }

        public void Brew()
        {
            _heater.On();
            _pump.Pump();
            Console.WriteLine(" [_]P coffee! [_]P ");
            _heater.Off();
        }
    }
}