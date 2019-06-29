using System;

namespace Domain
{
    public class InstrumentProcessor
    {
        private readonly ITaskDispatcher taskDispatcher;
        private readonly IInstrument instrument;
        private IConsole console;

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

        public void Process()
        {
            var currentTask = taskDispatcher.GetTask();
            instrument.Execute(currentTask);
        }

        private void OnInstrumentFinished(object sender, TaskFinishedEventHandlerArgs e)
        {
            taskDispatcher.FinishedTask(e.Task);
        }

        private void OnInstrumentError(object sender, EventArgs e)
        {
            console.WriteLine("Error occured");
        }
    }
}