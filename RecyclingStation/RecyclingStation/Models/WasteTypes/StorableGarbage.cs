namespace RecyclingStation.Models.WasteTypes
{
    using Framework.Attributes.GarbageAttributes;

    [StorableGarbage("StorableStrategy")]
    public class StorableGarbage : Waste
    {
        public StorableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
