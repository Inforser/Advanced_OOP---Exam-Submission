namespace RecyclingStation.Framework.GarbageDisposalStrategies
{
    using Attributes.StrategyAttributes;
    using Interfaces;

    [RecyclableStrategy]
    public class RecyclableDisposalStrategy : GarbageDisposalStrategy
    {
        private const double DefVolumeModifier = 0.5;

        private const double DefWeightModifier = 400D;

        protected override void DoActualProcessing(IWaste garbage)
        {
            this.EnergyUsed = this.GarbageVolume*DefVolumeModifier;
            this.CapitalEarned = garbage.Weight*DefWeightModifier;
        }
    }
}
