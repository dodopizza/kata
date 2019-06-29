using System;

namespace Domain
{
    public interface IInstrument
    {
        void Execute(string task);
        event EventHandler<TaskFinishedEventHandlerArgs> Finished;
        event EventHandler Error;
    }
}