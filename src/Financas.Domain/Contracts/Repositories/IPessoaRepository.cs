using Financas.Domain.Entities;
using System.Collections.Generic;

namespace Financas.Domain.Contracts.Repositories
{
	public interface IPessoaRepository : IRepository<Pessoa>
	{
		IEnumerable<Pessoa> GetAll();
		Pessoa Get(int idPessoa);
	}
}
