namespace Domain
{
    public class InstrumentProcessor
    {
        private readonly ITaskDispatcher _taskDispatcher;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher)
        {
            _taskDispatcher = taskDispatcher;
        }

        public string GetCurrentTask()
        {
            return _taskDispatcher.GetTask();
        }
    }
}