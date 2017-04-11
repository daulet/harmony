using System;

namespace Harmony.Samples.InjectionUsingHarmony
{
    public class ElectricHeater : IHeater
    {
        private bool _heating;

        public void On()
        {
            Console.WriteLine("~ ~ ~ heating ~ ~ ~");
            _heating= true;
        }

        public void Off()
        {
            _heating = false;
        }

        public bool IsHot()
        {
            return _heating;
        }
    }
}
