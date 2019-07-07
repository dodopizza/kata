using System;

namespace Domain
{
    public sealed class Instrument : IInstrument
    {
        public void Execute(string task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
        }

        public event EventHandler Finished;
        public event EventHandler Error;
    }
}