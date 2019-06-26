namespace Domain
{
    public class Copier
    {
        private readonly ISource _source;

        public Copier(ISource source, IDestination destination)
        {
            _source = source;
        }

        public void Copy()
        {
            _source.GetChar();
        }
    }
}