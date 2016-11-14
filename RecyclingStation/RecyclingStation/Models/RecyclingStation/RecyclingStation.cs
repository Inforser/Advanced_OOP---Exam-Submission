namespace RecyclingStation.Models.RecyclingStation
{
    using Framework.Interfaces;

    public class RecyclingStation : IRecyclingStation
    {
        private double energy;

        private double capital;

        public RecyclingStation()
        {
            this.energy = 0;
            this.capital = 0;
        }

        public void ProcessData(IProcessingData processingData)
        {
            this.energy += processingData.EnergyBalance;
            this.capital += processingData.CapitalBalance;
        }

        public string PrintState()
        {
            return $"Energy: {this.energy:F2} Capital: {this.capital:F2}";
        }
    }
}
