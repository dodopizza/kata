namespace Domain
{
    public sealed class InstrumentProcessor : IInstrumentProcessor
    {
        private readonly IInstrument _instrument;
        private readonly ITaskDispatcher _taskDispatcher;

        public InstrumentProcessor(IInstrument instrument, ITaskDispatcher taskDispatcher)
        {
            _instrument = instrument;
            _taskDispatcher = taskDispatcher;
        }

        public void Process()
        {
            var task = _taskDispatcher.GetTask();
            _instrument.Execute(task);
        }
    }
}