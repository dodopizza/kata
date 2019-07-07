using System;
using System.Threading.Tasks;

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

            Task.Run(() => ExecuteAsync(task));
        }

        private async Task ExecuteAsync(string task)
        {
            await Task.Delay(1).ConfigureAwait(false);
            
            Finished?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Finished;
        public event EventHandler Error;
    }
}