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

            if (task == "error")
            {
                Error?.Invoke(this, EventArgs.Empty);
            }
            
            Finished?.Invoke(this, new TaskFinishedEventArgs(task));
        }

        public event EventHandler<TaskFinishedEventArgs> Finished;
        public event EventHandler Error;
    }
}