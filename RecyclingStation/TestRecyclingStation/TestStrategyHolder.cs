namespace TestRecyclingStation
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RecyclingStation.Framework.Attributes.GarbageAttributes;
    using RecyclingStation.Framework.StrategyHolder;

    [TestClass]
    public class TestStrategyHolder
    {
        private IStrategyHolder strategyHolder;

        [TestInitialize]
        public void InitMethod()
        {
            this.strategyHolder = new StrategyHolder();
        }

        [TestMethod]
        public void AddStrategyMethodShouldCorrectlySaveTheNewStrategy()
        {
            var typeOfAttribute1 = typeof(DisposableAttribute);
            var typeOfAttribute2 = typeof(RecyclableGarbageAttribute);

            this.strategyHolder.AddStrategy(typeOfAttribute2, null);
            this.strategyHolder.AddStrategy(typeOfAttribute1, null);

            var numberOfMappings = this.strategyHolder.GetDisposalStrategies.Count;

            Assert.AreEqual(2, numberOfMappings);
        }

        [TestMethod]
        public void RemoveStrategyMethodShouldCorrectlyRemoveTheGivenMapping()
        {
            var typeOfAttribute1 = typeof(DisposableAttribute);
            var typeOfAttribute2 = typeof(RecyclableGarbageAttribute);
            var typeOfAttribute3 = typeof(BurnableGarbageAttribute);

            this.strategyHolder.AddStrategy(typeOfAttribute1, null);
            this.strategyHolder.AddStrategy(typeOfAttribute2, null);
            this.strategyHolder.AddStrategy(typeOfAttribute3, null);

            var numberOfMappings = this.strategyHolder.GetDisposalStrategies.Count;
            this.strategyHolder.RemoveStrategy(typeOfAttribute1);
            Assert.AreEqual(3, numberOfMappings);

            numberOfMappings = this.strategyHolder.GetDisposalStrategies.Count;
            Assert.AreEqual(2, numberOfMappings);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStrategyMethodShouldThrowExcIfDicttionaryAlreadyContainsKey()
        {
            var typeOfAttribute = typeof(DisposableAttribute);

            this.strategyHolder.AddStrategy(typeOfAttribute, null);
            this.strategyHolder.AddStrategy(typeOfAttribute, null);

            var numberOfMappings = this.strategyHolder.GetDisposalStrategies.Count;

            Assert.AreEqual(1, numberOfMappings);
        }

        [TestMethod]
        public void GetDisposalStrategiesShouldReturnTheCorrectStoredMappings()
        {
            var typeOfAttribute1 = typeof(DisposableAttribute);
            var typeOfAttribute2 = typeof(RecyclableGarbageAttribute);
            var typeOfAttribute3 = typeof(BurnableGarbageAttribute);

            this.strategyHolder.AddStrategy(typeOfAttribute1, null);
            this.strategyHolder.AddStrategy(typeOfAttribute2, null);
            this.strategyHolder.AddStrategy(typeOfAttribute3, null);

            var result1 = this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(DisposableAttribute));
            var result2 = this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(RecyclableGarbageAttribute));
            var result3 = this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(BurnableGarbageAttribute));

            Assert.IsTrue(
                result1 == result2 && 
                result2 == result3 && 
                result3 == true);
        }
    }
}
