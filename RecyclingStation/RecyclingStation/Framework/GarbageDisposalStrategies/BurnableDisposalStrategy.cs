namespace RecyclingStation.Framework.GarbageDisposalStrategies
{
    using Attributes.StrategyAttributes;
    using Interfaces;

    [BurnableStrategy]
    public class BurnableDisposalStrategy : GarbageDisposalStrategy
    {
        private const double DefVolumeModifier = 0.2;

        protected override void DoActualProcessing(IWaste garbage)
        {
            this.EnergyProduced = this.GarbageVolume;
            this.EnergyUsed = this.GarbageVolume * DefVolumeModifier;
        }
    }
}
