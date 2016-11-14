namespace RecyclingStation.LogicsEngine
{
    using Dispatchers;
    using IO.Readers;
    using IO.Writers;

    public class Engine : IMainEngine
    {
        private readonly IReader reader;

        private readonly IWriter writer;

        private readonly IDispatcher dispatcher;

        public Engine(IReader reader, IWriter writer, IDispatcher dispatcher)
        {
            this.reader = reader;
            this.writer = writer;
            this.dispatcher = dispatcher;
        }

        public void StartEventLoop()
        {
            while (true)
            {
                var input = this.reader.ReadLine();
                if (input == "TimeToRecycle")
                {
                    break;
                }

                string[] tokens = input.Split();
                var result = this.dispatcher.Dispatch(input);
                this.writer.WriteLine(result);
            }
        }
    }
}
