using Financas.Data.Mappings;
using Financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Financas.Data.Contexts
{
	public class FinancasContext : DbContext
	{
		public FinancasContext(DbContextOptions<FinancasContext> options)
			: base(options) { }

		public DbSet<Categoria> Categoria { get; set; }
		public DbSet<Pessoa> Pessoa { get; set; }
		public DbSet<ContaFinanceira> ContaFinanceira { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new CategoriaMapping());
			modelBuilder.ApplyConfiguration(new PessoaMapping());
			modelBuilder.ApplyConfiguration(new ContaFinanceiraMapping());
		}

	}
}