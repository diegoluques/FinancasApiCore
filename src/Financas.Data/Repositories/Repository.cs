using Financas.Data.Contexts;
using Financas.Domain.Bases;
using Financas.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace Financas.Data.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
	{
		protected readonly FinancasContext _context;
		protected readonly DbSet<TEntity> _dbSet;

		public Repository(FinancasContext context)
		{
			_context = context;
			_dbSet = this._context.Set<TEntity>();
		}

		public void Delete(TEntity entity)
		{
			 _dbSet.Remove(entity);
			Commit();
		}

		public void Save(TEntity entity)
		{
			_dbSet.Add(entity);
			entity.CreationDate = DateTime.Now;
			entity.CreatedById = 1;
			Commit();
		}

		public void Update(TEntity entity)
		{
			_dbSet.Update(entity);
			entity.ModifiedDate = DateTime.Now;
			entity.ModifiedById = 2;
			Commit();
		}
		public void Commit()
		{
			this._context.SaveChanges();
		}

		public DbConnection _db => _context.Database.GetDbConnection();
	}
}
