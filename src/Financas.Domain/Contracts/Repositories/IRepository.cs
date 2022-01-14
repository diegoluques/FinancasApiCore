using Financas.Domain.Bases;

namespace Financas.Domain.Contracts.Repositories
{
	public interface IRepository<TEntity> where TEntity : Entity
	{
		void Save(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}
}
