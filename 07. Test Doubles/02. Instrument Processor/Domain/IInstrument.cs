using System;

namespace Domain
{
    public interface IInstrument
    {
        void Execute(string task);
        event EventHandler<TaskFinishedEventArgs> Finished;
        event EventHandler Error;
    }
}