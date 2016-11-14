namespace RecyclingStation.Models.WasteTypes
{
    using Framework.Attributes.GarbageAttributes;

    [BurnableGarbage("BurnableStrategy")]
    public class BurnableGarbage : Waste
    {
        public BurnableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
