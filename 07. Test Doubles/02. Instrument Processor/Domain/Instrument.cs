using System;

namespace Domain
{
    public class Instrument : IInstrument
    {
        public void Execute(string task)
        {
            if (task is null) throw new NullReferenceException();
        }

        public event EventHandler<TaskFinishedEventHandlerArgs> Finished;
        public event EventHandler Error;
    }
}