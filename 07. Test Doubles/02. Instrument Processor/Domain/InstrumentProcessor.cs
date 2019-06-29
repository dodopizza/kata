using System;

namespace Domain
{
    public class InstrumentProcessor
    {
        private readonly ITaskDispatcher taskDispatcher;
        private readonly IInstrument instrument;
        private IConsole console;
        private string currentTask;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            this.taskDispatcher = taskDispatcher;
            this.instrument = instrument;
            console = new Console();
            
            this.instrument.Finished += OnInstrumentFinished;
            this.instrument.Error += OnInstrumentError;
        }

        public void ReplaceConsole(IConsole console)
        {
            this.console = console;
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