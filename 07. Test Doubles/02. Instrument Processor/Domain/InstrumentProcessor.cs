using System;

namespace Domain
{
    public class InstrumentProcessor
    {
        private readonly ITaskDispatcher taskDispatcher;
        private readonly IInstrument instrument;
        private string currentTask;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            this.taskDispatcher = taskDispatcher;
            this.instrument = instrument;
            this.instrument.Finished += OnInstrumentFinished;
        }

        public string GetCurrentTask()
        {
            return currentTask;
        }

        public void Process()
        {
            currentTask = taskDispatcher.GetTask();
            instrument.Execute(currentTask);
        }

        private void OnInstrumentFinished(object sender, EventArgs e)
        {
            taskDispatcher.FinishedTask(currentTask);
        }
    }
}