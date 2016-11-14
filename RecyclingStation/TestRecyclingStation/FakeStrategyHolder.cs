namespace TestRecyclingStation
{
    using System;
    using System.Collections.Generic;
    using RecyclingStation.Framework.Attributes.GarbageAttributes;
    using RecyclingStation.Framework.GarbageDisposalStrategies;
    using RecyclingStation.Framework.StrategyHolder;

    public class FakeStrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public FakeStrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            this.Init();
        }
        
        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies { get; }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            return true;
        }

        private void Init()
        {
            var typeOfAttribute1 = typeof(DisposableAttribute);
            var typeOfAttribute2 = typeof(RecyclableGarbageAttribute);
            var typeOfAttribute3 = typeof(BurnableGarbageAttribute);

            this.strategies.Add(typeOfAttribute1, null);
            this.strategies.Add(typeOfAttribute2, null);
            this.strategies.Add(typeOfAttribute3, null);
        }
    }
}
