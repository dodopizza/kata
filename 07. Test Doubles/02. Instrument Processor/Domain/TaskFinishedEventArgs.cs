using System;

namespace Domain
{
    public sealed class TaskFinishedEventArgs : EventArgs
    {
        public TaskFinishedEventArgs(string task)
        {
            Task = task ?? throw new ArgumentNullException(nameof(task));
        }
        
        public string Task { get; }
    }
}