namespace RecyclingStation.Framework.GarbageDisposalStrategies
{
    using Interfaces;
    using Models;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        protected double EnergyProduced { get; set; }

        protected double EnergyUsed { get; set; }

        protected double CapitalEarned { get; set; }

        protected double CapitalUsed { get; set; }
        ////
        protected double GarbageVolume { get; set; }
        
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            this.PrepareForProcess();
            this.CalculateGarbageVolume(garbage);
            this.DoActualProcessing(garbage);
            return this.CreateProcessingData();
        }

        protected void PrepareForProcess()
        {
            this.EnergyProduced = 0;
            this.EnergyUsed = 0;
            this.CapitalEarned = 0;
            this.CapitalUsed = 0;
        }
        
        protected abstract void DoActualProcessing(IWaste garbage);

        protected IProcessingData CreateProcessingData()
        {
            var totalEnergy = this.EnergyProduced - this.EnergyUsed;
            var totalCapital = this.CapitalEarned - this.CapitalUsed;
            var data = new ProcessingData(totalEnergy, totalCapital);
            return data;
        }

        private void CalculateGarbageVolume(IWaste garbage)
        {
            this.GarbageVolume = garbage.Weight * garbage.VolumePerKg;
        }
    }
}
