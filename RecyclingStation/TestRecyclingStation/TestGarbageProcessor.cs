namespace TestRecyclingStation
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RecyclingStation.Framework.GarbageProcessor;
    using RecyclingStation.Models;
    using RecyclingStation.Models.WasteTypes;

    [TestClass]
    public class TestGarbageProcessor
    {
        private IGarbageProcessor garbageProcessor;

        [TestInitialize]
        public void TestInit()
        {
            var strategyHolder = new FakeStrategyHolder();
            this.garbageProcessor = new GarbageProcessor(strategyHolder);
        }

        //[TestMethod]
        public void SomeMethod()
        {
            var waste = new RecyclableGarbage("Pesho", 12, 113);
            var resultData = this.garbageProcessor.ProcessWaste(waste);
            var expectedData = new ProcessingData(1123, 1132);
        }
    }
}
