namespace Domain
{
    public class InstrumentProcessor : IInstrumentProcessor
    {
        private readonly ITaskDispatcher _taskDispatcher;

        public InstrumentProcessor(IInstrument instrument, ITaskDispatcher taskDispatcher)
        {
            _taskDispatcher = taskDispatcher;
        }

        public void Process()
        {
            _taskDispatcher.GetTask();
        }
    }
}