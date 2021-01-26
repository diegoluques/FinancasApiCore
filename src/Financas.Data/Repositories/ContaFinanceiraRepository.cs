using Financas.Data.Contexts;
using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using System.Collections.Generic;

namespace Financas.Data.Repositories
{
	public class ContaFinanceiraRepository : Repository<ContaFinanceira>, IContaFinanceiraRepository
	{
		public ContaFinanceiraRepository(FinancasContext context)
			: base(context) { }

		public ContaFinanceira Get(int idContaFinanceira)
		{
			return _dbSet.Find(idContaFinanceira);
		}

		public IEnumerable<ContaFinanceira> GetAll()
		{
			return _dbSet;
		}
	}
}