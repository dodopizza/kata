using System;

namespace Domain
{
    public sealed class InstrumentProcessor : IInstrumentProcessor
    {
        private readonly IInstrument _instrument;
        private readonly ITaskDispatcher _taskDispatcher;

        public InstrumentProcessor(IInstrument instrument, ITaskDispatcher taskDispatcher, IConsole console = null)
        {
            _instrument = instrument ?? throw new ArgumentNullException(nameof(instrument));
            _taskDispatcher = taskDispatcher ?? throw new ArgumentNullException(nameof(taskDispatcher));

            _instrument.Finished += (s, e) =>
            {
                taskDispatcher.FinishedTask(e.Task);
            };

            if (console != null)
            {
                _instrument.Error += (s, e) => { console.Write("Error occurred"); };
            }
        }

        public void Process()
        {
            var task = _taskDispatcher.GetTask();
            _instrument.Execute(task);
        }
    }
}