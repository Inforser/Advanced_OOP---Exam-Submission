namespace RecyclingStation.Factories
{
    using Framework.Interfaces;

    public interface IFactory
    {
        IWaste CreateWaste(string input);
    }
}
