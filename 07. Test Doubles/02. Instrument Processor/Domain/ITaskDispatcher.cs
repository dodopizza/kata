namespace Domain
{
    public interface ITaskDispatcher
    {
        string GetTask();
        void FinishedTask(string task);
    }
}