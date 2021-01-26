using Financas.Domain.Entities;
using System.Collections.Generic;

namespace Financas.Domain.Contracts.Repositories
{
	public interface IContaFinanceiraRepository : IRepository<ContaFinanceira>
	{
		IEnumerable<ContaFinanceira> GetAll();
		ContaFinanceira Get(int idContaFinanceira);
	}
}