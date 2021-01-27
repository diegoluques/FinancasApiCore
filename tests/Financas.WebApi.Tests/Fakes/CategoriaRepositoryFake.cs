using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Financas.WebApi.Tests.Fakes
{
	public class CategoriaRepositoryFake : ICategoriaRepository
	{
		private readonly List<Categoria> _db;

		public CategoriaRepositoryFake()
		{
			_db = new List<Categoria>
			{
				new Categoria(1, "MERCADO"),
				new Categoria(2, "REMEDIOS"),
				new Categoria(3, "ESCOLA")
			};
		}

		public void Delete(Categoria entity)
		{
			this._db.Remove(entity);
		}

		public Categoria Get(int idCategoria)
		{
			return this._db.FirstOrDefault(c => c.IdCategoria == idCategoria);
		}

		public IEnumerable<Categoria> GetAll()
		{
			return this._db;
		}

		public void Save(Categoria entity)
		{
			throw new System.NotImplementedException();
		}

		public void Update(Categoria entity)
		{
			throw new System.NotImplementedException();
		}

		public static ICategoriaRepository Create()
		{
			return new CategoriaRepositoryFake();
		}
	}
}