using Harmony.Slow;

namespace Harmony.Samples.InjectionUsingHarmony
{
    internal class CoffeeApp
    {
        /// <summary>
        /// Based on example in https://google.github.io/dagger/users-guide.html
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var coffeeShop = new HarmonyBuilder<ICoffeeShop, DripCoffeeModule>() //DaggerCoffeeShop.builder()
                .AddModule(new DripCoffeeModule())
                .Build();

            coffeeShop.Maker().Brew();
        }
    }
}
