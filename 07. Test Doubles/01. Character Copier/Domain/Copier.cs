using System;

namespace Domain
{
    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(ISource source, IDestination destination)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _destination = destination ?? throw new ArgumentNullException(nameof(destination));
        }

        public void Copy()
        {
            var value = _source.GetChar();
            _destination.SetChar(value);
        }
    }
}