using System;

namespace Financas.Domain.Exceptions
{
	public class DomainException : Exception
	{
		public DomainException(string message) : base(message)
		{

		}
	}
}
