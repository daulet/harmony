namespace Harmony.Samples.InjectionUsingHarmony
{
    [Component(modules: typeof(DripCoffeeModule))]
    public interface ICoffeeShop
    {
        CoffeeMaker Maker();
    }
}
