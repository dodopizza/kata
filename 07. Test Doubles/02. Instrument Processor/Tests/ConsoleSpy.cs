using Domain;

namespace Tests
{
    public class ConsoleSpy : IConsole
    {
        public void WriteLine(string line)
        {
            LastMessage = line;
        }

        public string LastMessage { get; private set; }
    }
}