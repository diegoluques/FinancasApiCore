using Financas.Data.Contexts;
using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using System.Collections.Generic;

namespace Financas.Data.Repositories
{
	public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
	{
		public CategoriaRepository(FinancasContext context) 
			: base(context) { }

		public Categoria Get(int idCategoria)
		{
			return _dbSet.Find(idCategoria);
		}

		public IEnumerable<Categoria> GetAll()
		{
			return _dbSet;
		}
	}
}
