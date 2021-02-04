using System;

namespace Financas.WebApi.Controllers
{
	internal class ExceptionNotFound : Exception
	{ 

		public ExceptionNotFound(string message) : base(message)
		{
		}
		 
	}
}