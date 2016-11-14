namespace RecyclingStation.Framework.GarbageProcessor
{
    using System;
    using System.Linq;
    using Attributes.GarbageAttributes;
    using GarbageDisposalStrategies;
    using Interfaces;
    using StrategyHolder;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder { get; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            var typeOfGivenGarbage = garbage.GetType();
            DisposableAttribute disposalAttribute =
                (DisposableAttribute)
                    typeOfGivenGarbage.GetCustomAttributes(true)
                        .FirstOrDefault(x => x.GetType().BaseType == typeof(DisposableAttribute));

            IGarbageDisposalStrategy currentStrategy = this.TryGetMappedStrategy(disposalAttribute);

            return currentStrategy.ProcessGarbage(garbage);
        }

        private IGarbageDisposalStrategy TryGetMappedStrategy(DisposableAttribute disposalAttribute)
        {
            IGarbageDisposalStrategy currentStrategy;
            if (disposalAttribute == null ||
                !this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(), out currentStrategy))
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            return currentStrategy;
        }
    }
}