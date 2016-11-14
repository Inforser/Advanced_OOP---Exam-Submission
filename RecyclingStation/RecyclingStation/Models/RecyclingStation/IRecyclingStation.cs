namespace RecyclingStation.Models.RecyclingStation
{
    using Framework.Interfaces;

    public interface IRecyclingStation
    {
        void ProcessData(IProcessingData processingData);

        string PrintState();
    }
}
