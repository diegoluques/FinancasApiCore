using Financas.Data.Contexts;
using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using System.Collections.Generic;

namespace Financas.Data.Repositories
{
	public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
	{
		public PessoaRepository(FinancasContext context) 
			: base(context) { }

		public Pessoa Get(int idPessoa)
		{
			return _dbSet.Find(idPessoa);
		}

		public IEnumerable<Pessoa> GetAll()
		{
			return _dbSet;
		}
	}
}
