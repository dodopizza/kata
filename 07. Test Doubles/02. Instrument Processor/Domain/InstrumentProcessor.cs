using System;

namespace Domain
{
    public class InstrumentProcessor
    {
        private readonly ITaskDispatcher taskDispatcher;
        private readonly IInstrument instrument;
        private readonly IConsole console;
        private string currentTask;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument, IConsole console = null)
        {
            this.taskDispatcher = taskDispatcher;
            this.instrument = instrument;
            this.console = console ?? new Console();
            this.instrument.Finished += OnInstrumentFinished;
            this.instrument.Error += OnInstrumentError;
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

        private void OnInstrumentError(object sender, EventArgs e)
        {
            console.WriteLine("Error occured");
        }
    }
}