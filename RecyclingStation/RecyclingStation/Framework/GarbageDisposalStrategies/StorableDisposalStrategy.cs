namespace RecyclingStation.Framework.GarbageDisposalStrategies
{
    using Attributes.StrategyAttributes;
    using Interfaces;

    [StorableStrategy]
    public class StorableDisposalStrategy : GarbageDisposalStrategy
    {
        private const double DefVolumeModifier1 = 0.13;

        private const double DefVolumeModifier2 = 0.65;

        protected override void DoActualProcessing(IWaste garbage)
        {
            this.EnergyUsed = this.GarbageVolume*DefVolumeModifier1;
            this.CapitalUsed = this.GarbageVolume*DefVolumeModifier2;
        }
    }
}
