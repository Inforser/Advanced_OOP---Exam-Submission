namespace RecyclingStation.Factories
{
    using System;
    using Constants;
    using Framework.Interfaces;
    using Models.WasteTypes;

    public class WasteFactory : IFactory
    {
        public IWaste CreateWaste(string input)
        {
            var tokens = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var weight = double.Parse(tokens[1]);
            var volumePerKg = double.Parse(tokens[2]);
            var type = tokens[3];
            switch (type)
            {
                case "Recyclable":
                    return new RecyclableGarbage(name, weight, volumePerKg);
                case "Burnable":
                    return new BurnableGarbage(name, weight, volumePerKg);
                case "Storable":
                    return new StorableGarbage(name, weight, volumePerKg);
                default:
                    throw new ArgumentException(Messages.InvalidGarbageTypeMessage);
            }
        }
    }
}
