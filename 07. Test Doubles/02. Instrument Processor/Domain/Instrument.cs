using System;

namespace Domain
{
    public class Instrument : IInstrument
    {
        public void Execute(string task)
        {
            Error.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Finished;
        public event EventHandler Error;
    }
}