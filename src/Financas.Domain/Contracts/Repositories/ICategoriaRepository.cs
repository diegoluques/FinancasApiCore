using Financas.Domain.Entities;
using System.Collections.Generic;

namespace Financas.Domain.Contracts.Repositories
{
	public interface ICategoriaRepository : IRepository<Categoria>
	{ 
		IEnumerable<Categoria> GetAll();
		Categoria Get(int idCategoria);
	}
}
