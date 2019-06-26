namespace Domain
{
	public class Copier
	{
		private readonly ISource _source;
		private readonly IDestination _destination;

		public Copier(ISource source, IDestination destination)
		{
			_source = source;
			_destination = destination;
		}

		public void Copy()
		{
			_destination.SetChar(_source.GetChar());
		}
	}
}