namespace RecyclingStation
{
    using System.Reflection;
    using Dispatchers;
    using Factories;
    using Framework.GarbageProcessor;
    using Framework.StrategyHolder;
    using Framework.StrategyMapper;
    using IO.Readers;
    using IO.Writers;
    using LogicsEngine;
    using Models.RecyclingStation;
    using Providers.TypeProvider;

    public class RecyclingStationMain
    {
        public static void Main()
        {
            ITypeProvider typeProvider = new TypeProvider(Assembly.GetExecutingAssembly());
            IStrategyHolder strategyHolder = new StrategyHolder();
            IStrategyMapper strategyMapper = new StrategyMapper(strategyHolder, typeProvider);
            strategyMapper.Map();
            ////
            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IRecyclingStation recyclingStation = new RecyclingStation();
            IFactory factory = new WasteFactory();
            IDispatcher dispatcher = new CommandDispatcher(recyclingStation, garbageProcessor, factory);
            ////
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IMainEngine engine = new Engine(reader, writer, dispatcher);
            engine.StartEventLoop();
        }
    }
}
