namespace RecyclingStation.Dispatchers
{
    using System;
    using Constants;
    using Factories;
    using Framework.GarbageProcessor;
    using Models.RecyclingStation;

    public class CommandDispatcher : IDispatcher
    {
        private readonly IFactory wasteFactory;

        private readonly IRecyclingStation recyclingStation;

        private readonly IGarbageProcessor garbageProcessor;

        public CommandDispatcher(
            IRecyclingStation recyclingStation, 
            IGarbageProcessor garbageProcessor,
            IFactory factory)
        {
            this.recyclingStation = recyclingStation;
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = factory;
        }

        public string Dispatch(string input)
        {
            var firstSplit = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cmd = firstSplit[0];
            switch (cmd)
            {
                case "ProcessGarbage":
                    var parameters = firstSplit[1];
                    return this.ProcessGarbageCase(parameters);
                case "Status":
                    return this.recyclingStation.PrintState();
                case "ChangeManagementRequirement":
                    return string.Empty;
                default:
                    throw new ArgumentException(Messages.InvalidCommandMessage);
            }
        }

        private string ProcessGarbageCase(string parameters)
        {
            var waste = this.wasteFactory.CreateWaste(parameters);
            var newData = this.garbageProcessor.ProcessWaste(waste);
            this.recyclingStation.ProcessData(newData);

            var outputMessage = string.Format(
                Messages.SuccessfullyProcessedMessage,
                waste.Weight,
                waste.Name);
            return outputMessage;
        }
    }
}
