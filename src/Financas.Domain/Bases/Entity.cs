using System;

namespace Financas.Domain.Bases
{
	public class Entity
	{
		public int CreatedById { get; set; }
		public DateTime CreationDate { get; set; }
		public int? ModifiedById { get; set; }
		public DateTime? ModifiedDate { get; set; }
		 
	}
}
