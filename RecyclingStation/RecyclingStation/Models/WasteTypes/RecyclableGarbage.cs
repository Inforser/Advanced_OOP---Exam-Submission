namespace RecyclingStation.Models.WasteTypes
{
    using Framework.Attributes.GarbageAttributes;

    [RecyclableGarbage("RecyclableStrategy")]
    public class RecyclableGarbage : Waste
    {
        public RecyclableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
