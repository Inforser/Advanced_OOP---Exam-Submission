namespace RecyclingStation.Framework.StrategyMapper
{
    /// <summary>
    /// Interface that specifies the behaviour Strategy Mappers have to implement,
    /// which is to map DisposableAttribute derivatives to specific strategies.
    /// </summary>
    public interface IStrategyMapper
    {
        /// <summary>
        /// Maps DisposableAttribute derivatives to specific strategies.
        /// </summary>
        void Map();
    }
}
