namespace Domain
{
    public class InstrumentProcessor
    {
        private readonly ITaskDispatcher _taskDispatcher;
        private readonly IInstrument _instrument;
        private string _currentTask;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            _taskDispatcher = taskDispatcher;
            _instrument = instrument;
        }

        public string GetCurrentTask()
        {
            return _currentTask;
        }

        public void Process()
        {
            _currentTask = _taskDispatcher.GetTask();
            _instrument.Execute(_currentTask);
        }
    }
}