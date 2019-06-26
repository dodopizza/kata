namespace Domain
{
    public class InstrumentProcessor
    {
        private readonly ITaskDispatcher _taskDispatcher;
        private string _currentTask;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher)
        {
            _taskDispatcher = taskDispatcher;
        }

        public string GetCurrentTask()
        {
            return _currentTask;
        }

        public void Process()
        {
            _currentTask = _taskDispatcher.GetTask();
        }
    }
}