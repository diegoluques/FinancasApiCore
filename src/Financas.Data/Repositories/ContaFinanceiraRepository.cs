using Dapper;
using Financas.Data.Contexts;
using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
			// Lambda Expression 
			return this._context.ContaFinanceira.Include(c => c.Pessoa);
		}
		//public IEnumerable<ContaFinanceira> GetAll2()
		//{
		//	// Linq To Entity
		//	var result = from c in _context.ContaFinanceira
		//				 join p in _context.Pessoa on c.IdPessoa equals p.IdPessoa 
		//				 select c;

		//	return result;
		//}
		//public IEnumerable<ContaFinanceira> GetAll3()
		//{
		//	// Dapper
		//	var strQuery = @"select * 
		//					 from ContaFinanceira c
		//					 join Pessoa p on c.idPessoa = p.idPessoa";

		//	return _db.Query<ContaFinanceira, Pessoa, ContaFinanceira>(strQuery, (c, p) =>
		//	{
		//		c.Pessoa = p;
		//		return c;
		//	},
		//	splitOn: "idPessoa");
		//}
	}
}